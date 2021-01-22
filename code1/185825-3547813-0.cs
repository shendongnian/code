    public class Indexer<T>
    {
        private IList<T> _source;
    
        public Indexer(IList<T> source)
        {
            _source = source;
        }
    
        public T this[int index]
        {
            get { return _source[index]; }
            set { _source[index] = value; }
        }
    }
    
    public static class IndexHelper
    {
        public static Indexer<T> GetIndexer<T>(this IList<T> indexedCollection)
        {
            // could cache this result for a performance improvement,
            // if appropriate
            return new Indexer<T>(indexedCollection);
        }
    }
    
