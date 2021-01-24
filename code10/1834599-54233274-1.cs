    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.Configure<ErpSettings>(Configuration.GetSection("Erp"));
        services.AddTransient<CompanyFilter>();
    }
