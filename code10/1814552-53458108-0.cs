    public static class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) => { ... })
                .ConfigureLogging((webhostContext, builder) => {
                    builder.AddConfiguration(webhostContext.Configuration.GetSection("Logging"))
                    .AddFilter<ConsoleLoggerProvider>(logLevel => logLevel!=LogLevel.Information)
                    .AddConsole()
                    .AddDebug();
                })
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights();
    }
