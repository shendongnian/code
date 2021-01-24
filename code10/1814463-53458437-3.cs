    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IMYUserManager, MYUserManager>();
        
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
