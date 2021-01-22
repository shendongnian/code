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
            int index = 0;
            for (; index < _cache.Count; index++)
            {
                yield return _cache[index];
            }
            for (; _enumerator.MoveNext(); index++)
            {
                var current = _enumerator.Current;
                _cache.Add(current);
                yield return current;
            }
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
