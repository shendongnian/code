    public static IServiceCollection AddAsResourceServer(this IServiceCollection services, Action<AuthMiddlewareOptions> action = null)
    {
        if (action != null)
            services.Configure(action);
        // ...
        return services;
    }
