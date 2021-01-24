    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                 // Add configuration, logging, ...
                .ConfigureServices((hostContext, services) =>
                {
                    // Add your services with depedency injection.
                    services.AddSingleton<IHostedService, TimedHostedService>();
                });
    
            await hostBuilder.RunConsoleAsync();
        }
    }
