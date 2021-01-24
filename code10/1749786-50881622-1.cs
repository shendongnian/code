    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddMvc();
    }
