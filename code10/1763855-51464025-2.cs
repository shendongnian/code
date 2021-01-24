    public class RepositoryFactory
    {
        IServiceProvider _ioc; // This would be your IoC/DI Container
        public RepositoryFactory(IServiceProvider ioc)
        {
            _ioc = ioc;
        }
        // Resolve T passing in the provided `FoodieTenantContext` into the constructor
        public IRepository<T> CreateRepository<T>(FoodieTenantContext context) =>
            _ioc.Resolve<T>(context); 
        
    }
