    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.FileExtensions;
    using Microsoft.Extensions.Configuration.Json;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    
    namespace IOCEFCore
    {
    
        public class TheContext : DbContext
        {
            public TheContext(DbContextOptions<TheContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
        }
    
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
    
        class Program
        {
            private static readonly IConfigurationRoot _configuration;
            private static readonly string _connectionString;
    
            static Program()
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
    
            }
    
            static void ConfigureServices(IServiceCollection isc)
            {
                isc.AddSingleton(_ => _configuration);
    
                isc.AddDbContextPool<TheContext>(options => options.UseInMemoryDatabase("myContext"));
    
                isc.AddSingleton<TheApp>();
            }
    
            static void Main()
            {
                IServiceCollection isc = new ServiceCollection();
                ConfigureServices(isc);
    
                IServiceProvider isp = isc.BuildServiceProvider();
    
                isp.GetService<TheApp>().Run();
                Console.ReadLine();
            }
    
            class TheApp
            {
                readonly TheContext _theContext;
    
                public TheApp(TheContext theContext) => _theContext = theContext;
    
                public void Run()
                {
                    // Do something on _theContext  
                    _theContext.Users.Add(new User {Id = 1, Name = "Me"});
                    _theContext.SaveChanges();
    
                    foreach (var u in _theContext.Users)
                    {
                        Console.WriteLine("{0} : {1}", u.Id, u.Name);
                    }
                }
            }
        }
    }
