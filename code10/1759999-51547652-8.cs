    public class CachedLookup<T, TKey>
    {        
        private readonly ConcurrentDictionary<T, T> _hashSet;
        private readonly ConcurrentDictionary<TKey, List<T>> _lookup = new ConcurrentDictionary<TKey, List<T>>();
        public CachedLookup(ConcurrentDictionary<T, T> hashSet)
        {
            _hashSet = hashSet;
        }   
        public CachedLookup(IEqualityComparer<T> equalityComparer = default)
        {
            _hashSet = equalityComparer is null ? new ConcurrentDictionary<T, T>() : new ConcurrentDictionary<T, T>(equalityComparer);
        }
    
        public List<T> Get(TKey key) => _lookup.ContainsKey(key) ? _lookup[key] : null;
    
        public List<T> Get(TKey key, Func<TKey, List<T>> getData)
        {
            if (_lookup.ContainsKey(key))
                return _lookup[key];
    
            var result = DedupeAndCache(getData(key));
    
            _lookup.TryAdd(key, result);
    
            return result;
        }
        public async ValueTask<List<T>> GetAsync(TKey key, Func<TKey, Task<List<T>>> getData)
        {
            if (_lookup.ContainsKey(key))
                return _lookup[key];
    
            var result = DedupeAndCache(await getData(key));
    
            _lookup.TryAdd(key, result);
    
            return result;
        }
    
        public void Add(T value) => _hashSet.TryAdd(value, value);
    
        public List<T> AddOrUpdate(TKey key, List<T> data)
        {            
            var deduped = DedupeAndCache(data);
    
            _lookup.AddOrUpdate(key, deduped, (k,l)=>deduped);
    
            return deduped;
        }
    
        private List<T> DedupeAndCache(IEnumerable<T> input) => input.Select(v => _hashSet.GetOrAdd(v,v)).ToList();
    }
