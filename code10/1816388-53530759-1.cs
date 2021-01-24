    public class ConcurrentDictionaryFoo : IFoo<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, TValue> _dictionary 
            = new ConcurrentDictionary<TKey, TValue>();
        void AddThings(TKey key, TValue val)
        {
            _dictionary.TryAdd(key, val);
        }
        void RemoveThings(TKey key)
        {
            _dictionary.TryRemove(key);
        }
    }
