    public class KeyValueIndexer<K,V>
    {
        private Dictionary<K, V> myVal = new Dictionary<K, V>();
        public V this[K k]
        {
            get
            {
                return myVal[k];
            }
            set
            {
                myVal.Add( k, value );
            }
        }
    }
