    public static class StartupExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services,
            IConfiguration configuration)
        {
             services.AddSingleton<IUnitOfWork, UnitOfWork>();
             services.AddSingleton<IOrderRepository, OrderRepository>();
             services.AddSingleton<ICustomerRepository, CustomerRepository>();
             return services;
        }
    }
