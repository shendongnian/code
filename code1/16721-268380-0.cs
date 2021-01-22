    public class Mapper<K,T> : IEnumerable<T>
    {
        C5.TreeDictionary<K,T> KToTMap = new TreeDictionary<K,T>();
        C5.HashDictionary<T,K> TToKMap = new HashDictionary<T,K>();
        
        /// <summary>
        /// Initializes a new instance of the Mapper class.
        /// </summary>
        public Mapper()
        {
            KToTMap = new TreeDictionary<K,T>();
            TToKMap = new HashDictionary<T,K>();
        }
        public void Add(K key, T value)
        {
            KToTMap.Add(key, value);
            TToKMap.Add(value, key);
        }
        public bool ContainsKey(K key)
        {
            return KToTMap.Contains(key);
        }
        public int Count
        {
            get { return KToTMap.Count; }
        }
        
        public K this[T obj]
        {
            get
            {
                return TToKMap[obj];
            }
        }
        public T this[K obj]
        {
            get
            {
                return KToTMap[obj];
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return KToTMap.Values.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return KToTMap.Values.GetEnumerator();
        }
    }
