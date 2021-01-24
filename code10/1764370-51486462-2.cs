    public abstract class Test<T, TEnumerable> : IRepositoryLoader<T>
        Where TEnumerable : IEnumerable<T>
    {
        Func<IEnumerable<T>, TEnumerable> _enumerableResolver;
        public Test(Func<IEnumerable<T>, TEnumerable> enumerableResolver)
        {
             this._enumerableResolver = enumerableResolver
        }
        protected TEnumerable Source;
        public abstract IEnumerable<T> LoadData();
        private void IRepositoryRelouder.Reload() => 
            Source = this._enumerableResolver(LoadData());
    }
