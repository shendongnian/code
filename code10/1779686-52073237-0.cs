    public class CompositionRoot
    {
        private readonly IContainer _root;
        public CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SomeService>()
                    .WithParameter(ResolvedParameter.ForKeyed<Func<DbContext>>("Some"));
            builder.RegisterType<AnotherService>()
                    .WithParameter(ResolvedParameter.ForKeyed<Func<DbContext>>("Another"));
            builder.RegisterInstance<Func<DbContext>>(() => new DbContext("Some"))
                    .Keyed<Func<DbContext>>("Some");
            builder.RegisterInstance<Func<DbContext>>(() => new DbContext("Another"))
                    .Keyed<Func<DbContext>>("Another");
            _root = builder.Build();
        }
        public T GetService<T>()
        {
            return _root.Resolve<T>();
        }
    }
    public class SomeService
    {
        private readonly Func<DbContext> _dbFactory;
        public SomeService(Func<DbContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }
        public async Task<Model> GetMemberList(CancellationToken cancelToken)
        {
            using (var dbContext = _dbFactory())
            {
                // Code Goes Here....
            }
               
            return null;
        }
    }
    
    public class AnotherService
    {
        private readonly Func<DbContext> _dbFactory;
        public AnotherService(Func<DbContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }
        public async Task<Model> GetMemberList(CancellationToken cancelToken)
        {
            using (var dbContext = _dbFactory())
            {
                // Code Goes Here....
            }
            return null;
        }
    }
