    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseRouter(cfg =>
        {
            cfg.MapRoute("default", "segmentA/{segmentB}");
        });
    }
