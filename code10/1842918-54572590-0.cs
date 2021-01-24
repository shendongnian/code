    public static IServiceCollection SetupDependencyInjection(this 
        IServiceCollection services, IConfiguration config)
    {
        services.Configure<BrahBrahConfig>(config.GetSection("brahbrah"));
        return services;
    }
