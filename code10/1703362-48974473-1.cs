    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((WebHostBuilderContext, ConfigurationBuilder) =>
            {
                ConfigurationBuilder
                        .AddJsonFile("Secrets.json", optional: true);
                ConfigurationBuilder.AddEnvironmentVariables();
            })
            .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
            .Build();
