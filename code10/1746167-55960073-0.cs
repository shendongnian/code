        public class Settings
    {
        public string Sample { get; set; }
    }
    public class Service : IHostedService
    {
        private readonly ILogger<Service> _logger;
        private Settings _settings;
        public Service(ILogger<Service> logger,
            Settings settings)
        {
            _logger = logger;
            _settings = settings;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                       .ConfigureHostConfiguration(builder =>
                       {
                           builder.AddJsonFile("hostsettings.json", optional: true);
                       })
                       .ConfigureAppConfiguration((hostContext, builder) =>
                       {
                           builder.AddJsonFile("appsettings.json");
                           builder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                       })
                       .ConfigureLogging((hostContext, builder) =>
                       {
                           Log.Logger = new LoggerConfiguration()
                                        .ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                           builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                           builder.AddSerilog(dispose: true);
                       })
                       .ConfigureServices((hostContext, services) =>
                       {
                           var settings = hostContext.Configuration.GetSection("Configuration").Get<Settings>();
                           services.AddSingleton(settings);
                           services.AddHostedService<Service>();
                           services.AddLogging();
                           services.AddOptions();
                       })
                       .Build();
            using (host)
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();
            }
        }
    }
