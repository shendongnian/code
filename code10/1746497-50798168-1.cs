    public static class MyServiceCollectionExtensions {
        public static IServiceCollection AddMyDataLayer(this IServiceCollection services, string name = "DefaultConnection") {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("datasettings.json"); //<<< just an example
            
            var connectionStringConfig = builder.Build();
            
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<YourDbContext>((serviceProvider, options) =>
                    options
                        .UseSqlServer(connectionStringConfig.GetConnectionString(name))
                );
             return services;
        }
    }
    
