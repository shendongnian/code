    public static class IServiceCollectionExtension
    {
        public static void SetWaitAndRetryPolicy<T>(this IServiceCollection services) where T : class
        {
            services.AddHttpClient<T>((sp, client) =>
            {
                var options = sp.GetService<IOptions<MyConfig>>();
                ...
            });
        }
    }
