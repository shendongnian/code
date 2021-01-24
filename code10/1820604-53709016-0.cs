        public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
        {
            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                // Note:         ↓↓↓↓
                builder.ConfigureTestServices(services => 
                    services.AddOptions<SystemOptions>(configuration.GetSection("System"))
                );
            }
        }
