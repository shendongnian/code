    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<Kind1Configuration>(Configuration.GetSection("Kind1"));
        services.Configure<Kind2Configuration>(Configuration.GetSection("Kind2"));
    }
