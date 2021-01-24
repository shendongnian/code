    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SessionState>();
        }
        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<Main>("app");
        }
    }
