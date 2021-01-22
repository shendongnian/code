    class GeneralCache
    {
        private Dictionary<Type, CacheCollection> _collections;
        public GeneralCache()
        {
            _collections = new Dictionary<Type, CacheCollection>();
        }
    
        public T GetOrAddItem<T>(int id, Func<int, T> factory) where T : EntityBase
        {
            Type t = typeof(T);
    
            CacheCollection collection;
            if (!_collections.TryGetValue(t, out collection))
            {
                collection = _collections[t] = new CacheCollection<T>(factory);
            }
    
            CacheCollection<T> stronglyTyped = (CacheCollection<T>)collection;
            return stronglyTyped.Item(id);
        }
    }
