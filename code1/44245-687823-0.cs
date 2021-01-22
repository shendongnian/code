    public class Indexer {
        private Func<int, object> getter;        
        private Action<int, object> setter;
        public object this[int index] 
        {
            get { return getter(index); }
            set { setter(index, value); }
        }
        public Indexer(Func<int, object> g, Action<int, object> s) 
        {
            getter = g;
            setter = s;
        }
    }
    public static class IndexerExtensions
    {
        public static Indexer ToIndexer(this DataRow row)
        {
            return new Indexer(n => row[n], (n, v) => row[n] = v);
        }
        public static Indexer ToIndexer(this IDataReader row)
        {
            return new Indexer(n => row[n], (n, v) => row[n] = v);
        }
    }
 
