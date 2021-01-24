    [assembly: FunctionsStartup(typeof(BlazingDemo.Api.Startup))]
    namespace BlazingDemo.Api
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
                var apiConfig = new WeatherApiConfig();
                config.Bind(nameof(WeatherApiConfig), apiConfig);
            
                builder.Services.AddSingleton(apiConfig);
                builder.Services.AddHttpClient();
            }
        }
    }
