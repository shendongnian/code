        public class Program
        {
            public static void Main(string[] args)
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .ConfigureHealthWithDefaults(
                    builder =>
                    {
                        builder.HealthChecks.AddCheck("DatabaseConnected",
                    () => new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy("Database Connection OK")));
                    })
                    .UseHealth()
                    .UseStartup<Startup>();
        }
