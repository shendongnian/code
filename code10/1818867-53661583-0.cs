    public class DependencyInjection
    {
        private static ServiceProvider Provider;
        public static void AddServices(IServiceCollection services)
        {
            Provider = services.BuildServiceProvider();
        }
        public static T GetService<T>()
        {
            var serviceScopeFactory = Provider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                return scope.ServiceProvider.GetService<T>();
            }
        }
    }
