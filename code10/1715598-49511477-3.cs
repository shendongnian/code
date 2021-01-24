    public class DataAccessFactory<T1> : IDataAccessFactory<T1>
    {
        private readonly IComponentContext context;
        public DataAccessFactory(IComponentContext context)
        {
            this.context = context;
        }
        public IDataAccess<T1> Create<T2>()
        {
            return context.Resolve<IDataAccess<T1, T2>>();
        }
    }
