using Microsoft.AspNetCore.Identity;
using NetKubernetes.Models;

namespace NetKubernetes.Data;

public class LoadDatabase
{
    public static async Task InsertarData(AppDbContext context, UserManager<Usuario> usuarioManager)
    {
        if (!usuarioManager.Users.Any())
        {
            var usuario = new Usuario
            {
                Nombre = "Luis",
                Apellido = "Torres",
                Email = "mail@mail.com",
                UserName = "USERDEMO",
                Telefono = "123456789"
            };
            await usuarioManager.CreateAsync(usuario, "PasswordTH@N0$[CAFECAFE]");
        }
        if (!context.Inmuebles!.Any())
        {
            context.Inmuebles!.AddRange(
            new Inmueble
            {
                Nombre = "Casa de Playa",
                Direccion = "San Francisco",
                Precio = 4500M,
                FechaCreacion = DateTime.Now
            },
            new Inmueble
            {
                Nombre = "Casa de Invierno",
                Direccion = "San Antonio",
                Precio = 3500M,
                FechaCreacion = DateTime.Now
            }
            );
        }
        context.SaveChanges();
    }

}