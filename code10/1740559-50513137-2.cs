    public static IServiceCollection AddMyLibrary(this IServiceCollection services) {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IAuditor, Auditor>();  
        services.AddScoped<IMyService, MyService>();
        //...add other services as needed
        return services.  
    }
