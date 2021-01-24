    public static IWebHostBuilder BuildWebHost(string[] args) =>
        new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddUserSecrets<Startup>()
                    .AddEnvironmentVariables()
                    .AddCommandLine(args);
            })
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights();
