    static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Current Environment : {(string.IsNullOrEmpty(environment) ? "Development" : environment)}");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            var builder = new HostBuilder();
            builder.UseEnvironment("Development");
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            builder.ConfigureWebJobs(b =>
            {
                
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
                // b.AddTimers();
               
                b.AddServiceBus(c =>
                {
                    c.ConnectionString = "[Your Connection String]";
                });
            }).ConfigureServices((context, services)=>
            {
                services.AddSingleton<INameResolver>(new QueueNameResolver(config));
            });
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    public class QueueNameResolver : INameResolver
    {
        private readonly IConfiguration _configuration;
        public QueueNameResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(string name)
        {
            return _configuration[$"AppSettings:{name}"];
        }
    }
