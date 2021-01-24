    interface IDisposableEnumerable<T>:IEnumerable<T>, IDisposable
    {
    }
    static class PartiallyCachedEnumerable
    {
        public static IDisposableEnumerable<T> Create<T>(IEnumerable<T> source, int cachedCount)
        {
            if (source == null)
                throw new NullReferenceException(nameof(source));
            if (cachedCount < 1)
                throw new ArgumentOutOfRangeException(nameof(cachedCount));
            return new partiallyCachedEnumerable<T>(source, cachedCount);
        }
        private class partiallyCachedEnumerable<T>: IDisposableEnumerable<T>
        {
            private readonly IEnumerator<T> enumerator;
            private bool disposed;
            private readonly List<T> cache;
            private readonly bool hasMoreItems;
            public partiallyCachedEnumerable(IEnumerable<T> source, int cachedCount)
            {
                Debug.Assert(source != null);
                Debug.Assert(cachedCount > 0);
                enumerator = source.GetEnumerator();
                cache = new List<T>(cachedCount);
                var count = 0;
                while (enumerator.MoveNext() && count < cachedCount)
                {
                    cache.Add(enumerator.Current);
                    count += 1;
                }
                hasMoreItems = !(count < cachedCount);
            }
            public void Dispose()
            {
                if (disposed)
                    return;
                enumerator.Dispose();
                disposed = true;
            }
            public IEnumerator<T> GetEnumerator()
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(enumerator));
                foreach (var t in cache)
                    yield return t;
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
