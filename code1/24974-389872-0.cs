    class UpdateableSortedList<K,V> {
        private SortedList<K,V> list = new SortedList<K,V>();
        public delegate K ExtractKeyFunc(V v);
        private ExtractKeyFunc func;
        
        public UpdateableSortedList(ExtractKeyFunc f) { func = f; }
        public void Add(V v) {
            list[func(v)] = v;
        }
        public void Update(V v) {
            int i = list.IndexOfValue(v);
            if (i >= 0) {
                list.RemoveAt(i);
            }
            list[func(v)] = v;
        }
        public IEnumerable<T> Values { get { return list.Values; } }
    }
