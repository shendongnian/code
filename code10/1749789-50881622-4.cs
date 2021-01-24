    public void ConfigureServices(IServiceCollection services)
    {
        // This is only required for .NET Core 2.0
        services.AddOptions();
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddMvc();
    }
