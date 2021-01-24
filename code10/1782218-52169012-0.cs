    public class TwoWayCollection<A, B>
    {
        private Dictionary<A, HashSet<B>> byADictionary = new Dictionary<A, HashSet<B>>();
        private Dictionary<B, HashSet<A>> byBDictionary = new Dictionary<B, HashSet<A>>();
        public IEnumerable<B> Get(A a)
        {
            return byADictionary[a];
        }
        public IEnumerable<A> InverseGet(B b)
        {
            return byBDictionary[b];
        }
        public void Add(A a, B b)
        {
            if (!byADictionary.ContainsKey(a))
            {
                byADictionary[a] = new HashSet<B>();
            }
            byADictionary[a].Add(b);
            if (!byBDictionary.ContainsKey(b))
            {
                byBDictionary[b] = new HashSet<A>();
            }
            byBDictionary[b].Add(a);
        }
    }
