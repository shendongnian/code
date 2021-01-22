    public class TwoKeyDictionary<K1,K2,V>
    {
        private readonly Dictionary<Pair<K1,K2>, V> _dict;
    
        public V this[K1 k1, K2 k2]
        {
            get { return _dict[new Pair(k1,k2)]; }
        }
    
        private struct Pair
        {
            public K1 First;
            public K2 Second;
    
            public override Int32 GetHashCode()
            {
                return First.GetHashCode() ^ Second.GetHashCode();
            }
    
            // ... Equals, ctor, etc...
        }
    }
