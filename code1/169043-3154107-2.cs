    // In Presentation.csproj
    class PresentationController
    {
        public PresentationController(IDataContextFactory dataContextFactory, IRepositoryFactory repositoryFactory)
        {
            #region .NET 4 Contract
            Contract.Requires(dataContextFactory != null);
            Contract.Requires(repositoryFactory != null);
            #endregion
            _dataContextFactory = dataContextFactory;
            _repositoryFactory = repositoryFactory;
        }
    
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IRepositoryFactory _repositoryFactory;
    
        public void Action()
        {
            using (IDataContext dc = _dataContextFactory.CreateInstance())
            {
                var repo = _repositoryFactory.CreateUserRepository();
                // do stuff with repo...
            }
        }
    }
    // In Factories.API.csproj
    interface IDataContextFactory
    {
        IDataContext CreateInstance();
    }
    interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository();
        IAddressRepository CreateAddressRepository();
        // etc.
    }
    // In Factories.Impl.csproj
    class DataContextFactory: IDataContextFactory
    {
        public IDataContext CreateInstance()
        {
            var context = IoC.Resolve<IDataContext>();
            // Do any common setup or initialization that may be required on 'context'
            return context;
        }
    }
    class RepositoryFactory: IRepositoryFactory
    {
        public IUserRepository CreateUserRepository()
        {
            var repo = IoC.Resolve<IUserRepository>();
            // Do any common setup or initialization that may be required on 'repo'
            return repo;
        }
        public IAddressRepository CreateAddressRepository()
        {
            var repo = IoC.Resolve<IAddressRepository>();
            // Do any common setup or initialization that may be required on 'repo'
            return repo;
        }
        // etc.
    }
