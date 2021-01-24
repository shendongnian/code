    public void ConfigureServices(IServiceCollection services)
        {
            // Dependency Injection
            services.AddScoped<ILogger, MyLoggerClass>();
     }
