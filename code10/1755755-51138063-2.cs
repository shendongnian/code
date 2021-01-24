    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    
        //I can read the AppSettings values here via Configuration..
    
        var settings = new ApplicationSettings(Configuration);
        services.AddSingleton(settings);
        // use whatever lifetime you prefer
        services.AddScoped<ToolService>();
    }
