    public void Configure(IApplicationBuilder app)
    {
        // Serve my app-specific default file, if present.
        DefaultFilesOptions options = new DefaultFilesOptions();
        options.DefaultFileNames.Clear();
        options.DefaultFileNames.Add("mydefault.html");
        app.UseDefaultFiles(options);
        app.UseStaticFiles();
    }
