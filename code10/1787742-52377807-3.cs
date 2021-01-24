    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // ...
        app.UseRouter(BuildRouter(app));
    }
