    public void ConfigureServices(IServiceCollection services)
    {
        // existing code
        services.AddTransient<IMyClass, MyClass>();
    }
