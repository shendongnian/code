    public class MultikeyDictionary<K1, K2, K3, V> : MultikeyDictionary<KeyValuePair<K1, K2>, K3, V>
    {
        public V this[K1 index1, K2 index2, K3 index3]
        {
            get
            {
                return base[new KeyValuePair<K1, K2>(index1, index2), index3];
            }
            set
            {
                base[new KeyValuePair<K1, K2>(index1, index2), index3] = value;
            }
        }
    
        public bool Remove(K1 index1, K2 index2, K3 index3)
        {
            return base.Remove(new KeyValuePair<K1, K2>(index1, index2), index3);
        }
    
        public void Add(K1 index1, K2 index2, K3 index3, V value)
        {
            base.Add(new KeyValuePair<K1, K2>(index1, index2), index3, value);
        }
    }
