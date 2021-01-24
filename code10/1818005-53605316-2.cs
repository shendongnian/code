    public void ConfigureServices(IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // Or you can also register as follows
        services.AddHttpContextAccessor();
    }
