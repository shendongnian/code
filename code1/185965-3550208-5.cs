    class GeneralCache
    {
        private Dictionary<Type, ICacheCollection> _collections;
        public GeneralCache()
        {
            _collections = new Dictionary<Type, ICacheCollection>();
        }
    
        public T GetOrAddItem<T>(int id, Func<int, T> factory) where T : EntityBase
        {
            Type t = typeof(T);
    
            ICacheCollection collection;
            if (!_collections.TryGetValue(t, out collection))
            {
                collection = _collections[t] = new CacheCollection<T>(factory);
            }
    
            CacheCollection<T> stronglyTyped = (CacheCollection<T>)collection;
            return stronglyTyped.Item(id);
        }
    }
