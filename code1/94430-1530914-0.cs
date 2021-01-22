    public class Set<T> : KeyedCollection<T,T>
    {
        public Set()
        {}
        public Set(IEqualityComparer<T> comparer) : base(comparer)
        {}
        public Set(IEnumerable<T> collection)
        {
            foreach (T elem in collection)
            {
                Add(elem);
            }
        }
        protected override T GetKeyForItem(T item)
        {
            return item;
        }
    }
