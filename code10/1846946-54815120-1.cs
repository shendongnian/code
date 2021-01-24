    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services.AddSingleton<IUrlHelperFactory, CustomUrlHelperFactory>();
    }
