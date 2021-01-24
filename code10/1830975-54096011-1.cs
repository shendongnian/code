<!-- -->
    public class MockInjectorFilter : IStartupConfigureServicesFilter
    {
        private readonly Action<IServiceCollection> _configureServices;
        public ConfigureTestServicesStartupConfigureServicesFilter(Action<IServiceCollection> configureServices)
            => _configureServices = configureServices ?? throw new ArgumentNullException(nameof(configureServices));
        public Action<IServiceCollection> ConfigureServices(Action<IServiceCollection> next)
            => serviceCollection =>
            {
                next(serviceCollection);
                _configureServices(serviceCollection);
            };
    }
