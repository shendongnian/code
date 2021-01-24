    using System;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using BethanysPieShop.Models;
    namespace BethanysPieShop
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var host = CreateWebHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<AppDbContext>();
                                            DbInitializer obj = new DbInitializer();
                    obj.Seed(context);
                    }
                    catch (Exception)
                    {
                        //we could log this in a real-world situation
                    }
                    host.Run();
                }
            }
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        }
    }
