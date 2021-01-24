    public class MultiDictionary<K, V>
    {
        private readonly Dictionary<K, HashSet<V>> d = new Dictionary<K, HashSet<V>>();
        public void Add(K k, V v)
        {
            if (!d.ContainsKey(k)) d.Add(k, new HashSet<V>());
            d[k].Add(v);
        }
        public void Remove(K k, V v)
        {
            if (d.ContainsKey(k))
            {
                d[k].Remove(v);
                if (d[k].Count == 0) d.Remove(k);
            }
        }
        public void Remove(K k) => d.Remove(k);
        public IEnumerable<V> GetValues(K k) => d.ContainsKey(k) ? d[k] : Enumerable.Empty<V>();
        public IEnumerable<K> GetKeys() => d.Keys;
    }
