    public static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            var startup = new Startup();
            var hostBuilder = new HostBuilder()
                .ConfigureHostConfiguration(startup.ConfigureHostConfiguration)
                .ConfigureAppConfiguration(startup.ConfigureAppConfiguration)
                .ConfigureLogging(startup.ConfigureLogging)
                .ConfigureServices(startup.ConfigureServices)
                .Build();
            await hostBuilder.RunAsync();
        }
