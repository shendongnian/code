            public static IServiceCollection ConfigureSqlCache(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<SqlServerCacheOptions>>();
            int result = CreateTableAndIndexes(options.Value);
            return services;
        }
