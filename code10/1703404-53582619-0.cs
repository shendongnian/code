    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
        app.UseDeveloperExceptionPage()
            .UseSession()
            .UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
            })
            .UseDirectoryBrowser()
            .UseRequestLocalization()
            .UseMvcWithDefaultRoute();
    }
