    public class FooService
    {
        public FooService(
            IUnitOfWorkFactory<EntityFrameworkUnitOfWork> factory,
            IRepositoryContext context,
            IWriteableRepository<Bar> repository)
        {
            this.UnitOfWorkFactory = factory;
            this.Context = context;
            this.Repository = repository;
        }
        private IUnitOfWorkFactory<EntityFrameworkUnitOfWork> UnitOfWorkFactory { get; set; }
        private IRepositoryContext Context { get; set; }
        private IWriteableRepository<Bar> Repository { get; set; }
        public bool RemoveBar(int baz)
        {
            // IUnitOfWorkFactory<T>.Begin(IRepositoryContext)
            //     where T : IUnitOfWork, new()
            // 
            // 1) Creates a new IUnitOfWork instance by calling parameterless constructor
            // 2) Call UseContext(IRepositoryContext) on UoW, passing in the context;
            //        This causes the UoW to use the passed-in context
            // 3) Calls .Begin() on the UoW
            // 4) Returns the UoW
            using (var unitOfWork = this.UnitOfWorkFactory.Begin(this.Context))
            {
                var bar = this.Repository
                    .Query()
                    .First(x => x.Baz == baz);
                this.Repository.Remove(bar);
                var (success, rows) = unitOfWork.Commit();
                return success && rows > 0;
            }
        }
    }
