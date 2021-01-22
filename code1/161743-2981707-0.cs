    public class ShortCollection<T> : IList<T>
    {
        protected Collection<T> innerCollection;
        protected int maxSize = 10;
        public IEnumerator<T> GetEnumerator()
        {
            return innerCollection.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
             return GetEnumerator();
        }
    }
