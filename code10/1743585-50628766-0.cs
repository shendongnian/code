    public void ConfigureServices(IServiceCollection services)
    {
        // container will create the instance of this type
        services.AddScoped<ConcreteRepository>();
    }
