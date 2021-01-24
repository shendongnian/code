    public class Factory<T> : IFactory<T>
    {
        private readonly Func<T> _initFunc;
        public Factory(Func<T> initFunc)
        {
            _initFunc = initFunc;
        }
        public T Create()
        {
            return _initFunc();
        }
    }
    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService, TImplementation>(this IServiceCollection services) 
        where TService : class
        where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
            services.AddSingleton<IFactory<TService>, Factory<TService>>();
        }
    }
