    public class DelegateDbContextProvider : IDbContextProvider
    {
        private readonly Func<MyDbContext> provider;
        public DelegateDbContextProvider(Func<MyDbContext> provider)
            => this.provider = provider;
        public MyDbContext Context => this.provider();
    }
