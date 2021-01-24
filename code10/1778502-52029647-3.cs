    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks();
        services.AddSingleton<SomeDependency>();
        // register the custom health check 
        // after AddHealthChecks and after SomeDependency 
        services.AddSingleton<IHealthCheck, SomeHealthCheck>();
    }
