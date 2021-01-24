    public static class IWebHostExtensions
    {
        public static IWebHostBuilder MigrateDbContext<TContext>(this IWebHostBuilder webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Build().Services.CreateScope()) //<-- HERE
            {
                //...
                
