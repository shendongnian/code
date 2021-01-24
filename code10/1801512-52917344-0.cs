    public static async Task Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureHostConfiguration(configHost => {...})
            .ConfigureAppConfiguration((hostContext, configApp) =>
               {...})
            .ConfigureServices((hostContext, services) =>
            {
               services.AddHostedService<ApplicationLifetime>();          
               ...
               services.AddOptions<HostOptions>().Configure(
                    opts => opts.ShutdownTimeout = TimeSpan.FromSeconds(10));
            })
            .ConfigureLogging(...)
            .UseConsoleLifetime()
            .Build();
        try
        {
            await host.RunAsync();
        }
        catch(OperationCanceledException)
        {
            ; // suppress
        }
    }
    
