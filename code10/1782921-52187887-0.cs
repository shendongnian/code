    static class ServiceCollectionExtensions
    {
        public static void AddRepository<TInterface, TRepository, TModel>(this IServiceCollection serviceCollection) 
            where TInterface : IRepository<TModel> 
            where TRepository : TInterface
        {
            services.AddScoped<TInterface, TRepository>();
            services.AddScoped<IRepository<TModel>, TRepository>();
        }
    }
    // usage:
    services.AddRepository<ITestRepository, TestRepository, Model>();
