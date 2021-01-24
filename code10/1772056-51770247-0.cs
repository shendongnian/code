    public void Configure(IApplicationBuilder app)
    {
        var provider = new FileExtensionContentTypeProvider();
        // Add new mappings
        provider.Mappings[".myapp"] = "application/x-msdownload";
    
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
            RequestPath = "/StaticContentDir",
            ContentTypeProvider = provider
        });
