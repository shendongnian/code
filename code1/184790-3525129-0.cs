    public class StickyEnumerable<T> : IEnumerable<T>, IDisposable
    {
        private IEnumerator<T> innerEnumerator;
        public StickyEnumerable( IEnumerable<T> items )
        {
            innerEnumerator = items.GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return innerEnumerator;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerEnumerator;
        }
        public void Dispose()
        {
            if (innerEnumerator != null)
            {
                innerEnumerator.Dispose();
            }
        }
    }
