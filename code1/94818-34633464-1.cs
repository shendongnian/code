    public class CachedEnumerable<T> : IEnumerable<T>
    {
        readonly IEnumerator<T> _enumerator;
        readonly List<T> _cache = new List<T>();
        public CachedEnumerable(IEnumerable<T> enumerable) 
            : this(enumerable.GetEnumerator())
        {
        }
        public CachedEnumerable(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }
        public IEnumerator<T> GetEnumerator()
        {
            // The index of the current item in the cache.
            int index = 0;
            // Enumerate the _cache first
            for (; index < _cache.Count; index++)
            {
                yield return _cache[index];
            }
            // Continue enumeration of the original _enumerator, 
            // until it is finished. 
            // This adds items to the cache and increment 
            for (; _enumerator.MoveNext(); index++)
            {
                var current = _enumerator.Current;
                _cache.Add(current);
                yield return current;
            }
            // Some other users of the same instance of CachedEnumerable
            // can add more items to the cache, 
            // so we need to enumerate them as well
            for (; index < _cache.Count; index++)
            {
                yield return _cache[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
