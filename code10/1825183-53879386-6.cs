    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddTransient<ClassB>();
        services.AddTransient<ClassA>();
    }
