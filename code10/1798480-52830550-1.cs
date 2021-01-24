        public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<JobStorage>(x =>
                {
                    return GlobalConfiguration.Configuration.UseMemoryStorage();
                });
            });
        }
    }
