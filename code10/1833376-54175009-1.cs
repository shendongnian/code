    // get the directory
    var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
    var assetDirectory = Path.Combine(assemblyDirectory, "Assets"));
    // use it
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(assetDirectory),
        RequestPath = "/Assets"
    });
