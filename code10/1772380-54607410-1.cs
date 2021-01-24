    public void ConfigureServices(IServiceCollection services)
    {
        // Configure Simple Proxy
        services.EnableSimpleProxy(p => p.AddInterceptor<ConsoleLogAttribute, ConsoleLogInterceptor>());
    
        // Configure your services using the Extension Methods
        services.AddTransientWithProxy<ITestClass, TestClass>();
    }
