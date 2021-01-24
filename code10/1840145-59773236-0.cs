    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
        }
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
        private IConfiguration GetConfiguration()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json");
            return new ConfigurationBuilder()
                .AddJsonStream(stream) // key method to use, reads JSON stream
                .Build(); // builds the configuration from embedded stream
        }
    }
