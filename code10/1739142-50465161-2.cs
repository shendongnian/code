        public static class Injector
        {
            // you probably want to pass the connection string or an Options class here too
            public static IServiceCollection Inject(this IServiceCollection services)
            {
                services.AddDbContext<...>(...);
                return services;
            }
        }
