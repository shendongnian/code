    public class Program {
        public static void Main(string[] args) {
            BuildWebHost(args)
                .MigrateDbContext<ApplicationDbContext>((context, services) => {
                    var env = services.GetService<IHostingEnvironment>();
                    var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
                    new ApplicationDbContextSeed()
                        .SeedAsync(context, env, logger)
                        .Wait();
                })
                .Run();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) => {
                    config.AddEnvironmentVariables();
                })
                .Build();
    }
