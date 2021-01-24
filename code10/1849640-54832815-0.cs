    public class ScopedFooFactory : IFooFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ScopedFooFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IFoo CreateFoo()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return scope.ServiceProvider.GetService<IFoo>();
            }
        }
    }
