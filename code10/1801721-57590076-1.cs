            public void ConfigureServices(IServiceCollection services)
            {
                var serviceProvider = services.BuildServiceProvider();
                var logger = serviceProvider.GetService<ILogger<ApplicationLog>>();
                services.AddSingleton(typeof(ILogger), logger);
                ...
             }
