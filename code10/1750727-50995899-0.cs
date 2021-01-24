    app.UseStaticFiles(new StaticFileOptions {
        FileProvider = new EmbeddedFileProvider(
            assembly: Assembly.GetAssembly(typeof(SomeClassFromAssembly)),
            baseNamespace: "OpenIddict.Assets")
    });
