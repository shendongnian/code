    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
    
            // allows us to read the configuration file from current directory
            // (remember to copy those files to the OutputDirectory in VS)
            builder.UseContentRoot(Directory.GetCurrentDirectory());
    
            // configure things like batch size, service bus, etc..
            builder.ConfigureWebJobs(b =>
            {
                b
                .AddAzureStorageCoreServices()
                .AddAzureStorage(options =>
                {
                    options.BatchSize = 1;
                    options.MaxDequeueCount = 1;
                })
                ;
            });
    
            // this step allows the env variable to be read BEFORE the rest of the configuration
            // => this is useful to configure the hosting environment in debug, by setting the 
            // ENVIRONMENT variable in VS
            builder.ConfigureHostConfiguration(config =>
            {
                config.AddEnvironmentVariables();
            });
    
            // reads the configuration from json file
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;
    
                // Adding command line as a configuration source
                config
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    
                config.AddEnvironmentVariables();
                if (args != null)
                    config.AddCommandLine(args);
            });
    
            // configure logging (you can use the config here, via context.Configuration)
            builder.ConfigureLogging((context, loggingBuilder) =>
            {
                loggingBuilder.AddConfiguration(context.Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
    
                // If this key exists in any config, use it to enable App Insights
                var appInsightsKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                if (!string.IsNullOrEmpty(appInsightsKey))
                {
                    loggingBuilder.AddApplicationInsights(o => o.InstrumentationKey = appInsightsKey);
                }
            });
    
            // inject dependencies via DI
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<INameResolver>(new QueueNameResolver("test"));
    
                services.AddDbContextPool<DbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DbContext"))
                );
            });
    
            // finalize host config
            builder.UseConsoleLifetime();
    
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
