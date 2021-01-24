    public static IServiceCollection AddRoleBasedContractResolver(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IConfigureOptions<MvcJsonOptions>, RoleBasedContractResolverOptions>();
        return services;
    }
