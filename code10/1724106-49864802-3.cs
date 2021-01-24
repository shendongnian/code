    public static class CustomOutputServiceCollectionExtensions {
    
        public IServiceCollection ConfigureCustomOutput(this IServiceCollection services) {
            services.AddTransient<IMyRepository, MyRepository>();
            
            var logger = new Lazy<ILogger>(() => {
                var sp = services.BuildServiceProvider();
                return sp.GetService<ILogger<CustomOutput>>();
            });
            
            var repository = new Lazy<IMyRepository>(() => {
                var sp = services.BuildServiceProvider();
                return sp.GetService<IMyRepository>();
            });
            
            CustomOutput.Instance.Configure(logger, repository);
            
            return services;
        }
    
    }
