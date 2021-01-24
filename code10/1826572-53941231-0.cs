    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseCors("AllowAllOrigins");
        // Other middleware
    }
