    public class BaseRepositoryFactory<T1> : IDataAccessFactory<T1>
    {
        private readonly IComponentContext context;
        public BaseRepositoryFactory(IComponentContext context)
        {
            this.context = context;
        }
        public IDataAccess<T1> Create<T2>()
        {
            return context.Resolve<RepositoryBase<T1, T2>>();
        }
    }
    public interface IDataAccessFactory<T1>
    {
        IDataAccess<T1> Create<T>();
    }
