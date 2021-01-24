    public class MyRepository : ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
    
        public MyRepository()
        {
            AbpSession = NullAbpSession.Instance;
        }
    }
