    public void ConfigureServices(IServiceCollection services)
    {            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        ....
        // In production, the Angular files will be served from this directory
        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/dist/ClientApp";//change here
        });
         ...
    }
