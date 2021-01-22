    public class MultiDictionary<K1, K2, V>
    {
        private Dictionary<K1, Dictionary<K2, V>> dict = 
            new Dictionary<K1, Dictionary<K2, V>>();
        public V this[K1 key1, K2 key2]
        {
            get
            {
                return dict[key1][key2];
            }
            set
            {
                if (!dict.ContainsKey(key1))
                {
                    dict[key1] = new Dictionary<K2, V>();
                }
                dict[key1][key2] = value;
            }
        }
    }
