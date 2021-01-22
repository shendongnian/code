    public class SafeEnumerable<T> : IEnumerable<T>, IDisposable
    {
        private IEnumerable<T> _source;
        private IEnumerator<T> _enumerator;
        private T[] _cached;
        public SafeEnumerable(IEnumerable<T> source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (_source == null) throw new ObjectDisposedException(this.GetType().Name);
            if (_enumerator == null)
            {
                _enumerator = _source.GetEnumerator();
                _cached = _source.ToArray();
            }
            else
            {
                var modified = false;
                if (_source is ICollection collection) // C# 7 syntax
                {
                    modified = _cached.Length != collection.Count;
                }
                if (!modified)
                {
                    try
                    {
                        _enumerator.MoveNext();
                    }
                    catch (InvalidOperationException)
                    {
                        modified = true;
                    }
                }
                if (modified)
                {
                    _enumerator.Dispose();
                    _enumerator = _source.GetEnumerator();
                    _cached = _source.ToArray();
                }
            }
            foreach (var item in _cached)
            {
                yield return item;
            }
        }
        public void Dispose()
        {
            _enumerator?.Dispose();
            _enumerator = null;
            _cached = null;
            _source = null;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public static SafeEnumerable<T> AsSafeEnumerable<T>(this IEnumerable<T> source)
        => new SafeEnumerable<T>(source);
