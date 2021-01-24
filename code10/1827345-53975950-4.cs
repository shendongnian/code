    public partial class Startup
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IAntiforgery antiforgery)
            {
                app.UseMvcWithDefaultRoute();
            }
        }
