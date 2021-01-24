    public class CompositionRoot
    {
        private readonly IContainer _root;
        public CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SomeService>();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();
            _root = builder.Build();
        }
        public T GetService<T>()
        {
            return _root.Resolve<T>();
        }
    }
    public interface IDbContextFactory
    {
        DbContext Get(int clientId);
    }
    public class DbContextFactory : IDbContextFactory
    {
        public DbContext Get(int clientId)
        {
            // place here any logic you like to build connection string
            var connection = $"Data Source={clientId}db";
            return new DbContext(new SqlConnection(connection), true);
        }
    }
    public class SomeService
    {
        private readonly IDbContextFactory _dbFactory;
        public SomeService(IDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }
        public async Task<Model> GetMemberList(CancellationToken cancelToken, int clientId)
        {
            using (var dbContext = _dbFactory.Get(clientId))
            {
                // Code Goes Here....
            }
               
            return null;
        }
    }
