    namespace Microsoft.Extensions.DependencyInjection  {
        public static void AddModule(this IServiceCollection services, string connectionString) {
            services.AddDbContext<MyContext>(contextOptions => contextOptions.UseSqlServer(connectionString));
        }
    }
