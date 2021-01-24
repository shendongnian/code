    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions 
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Content")),
            RequestPath = "/Content"
        });
    }
