    public class MultikeyDictionary<K1, K2, V> : Dictionary<KeyValuePair<K1, K2>, V>
    {
        public V this[K1 index1, K2 index2]
        {
            get
            {
                return this[new KeyValuePair<K1, K2>(index1, index2)];
            }
            set
            {
                this[new KeyValuePair<K1, K2>(index1, index2)] = value;
            }
        }
    
        public bool Remove(K1 index1, K2 index2)
        {
            return base.Remove(new KeyValuePair<K1,K2>(index1, index2));
        }
    
        public void Add(K1 index1, K2 index2, V value)
        {
            base.Add(new KeyValuePair<K1, K2>(index1, index2), value);
        }
    }
