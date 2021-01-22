    public sealed class Cache : IEnumerable
    {
        // Fields
        private CacheInternal _cacheInternal;
        public static readonly DateTime NoAbsoluteExpiration;
        public static readonly TimeSpan NoSlidingExpiration;
    
        // Methods
        static Cache();
        [SecurityPermission(SecurityAction.Demand, Unrestricted=true)]
        public Cache();
        internal Cache(int dummy);
        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        public object Get(string key);
        internal object Get(string key, CacheGetOptions getOptions);
        public IDictionaryEnumerator GetEnumerator();
        public void Insert(string key, object value);
        public void Insert(string key, object value, CacheDependency dependencies);
        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        public object Remove(string key);
        internal void SetCacheInternal(CacheInternal cacheInternal);
        IEnumerator IEnumerable.GetEnumerator();
    
        // Properties
        public int Count { get; }
        public long EffectivePercentagePhysicalMemoryLimit { get; }
        public long EffectivePrivateBytesLimit { get; }
        public object this[string key] { get; set; }
    }
