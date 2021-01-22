    public class MyDictionary<K, V>
    {
        Dictionary<K, V> o = new Dictionary<K, V>();
        public delegate V NonExistentKey(K k);
        NonExistentKey nonExistentKey;
        public MyDictionary(NonExistentKey nonExistentKey_)
        {   o = new Dictionary<K, V>();
            nonExistentKey = nonExistentKey_;
        }
        public V this[K k]
        {
            get {
                V v;
                if (!o.TryGetValue(k, out v))
                {
                    v = nonExistentKey(k);
                    o[k] = v;
                }
                return v;
            }
            set {o[k] = value;}
        }
   }
