    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        private IEqualityComparer<T> _itemEqualityComparer = EqualityComparer<T>.Default;
        private IComparer<T> _itemComparer = Comparer<T>.Default;
    
        public ListEqualityComparer() { }
    
        public ListEqualityComparer(IEqualityComparer<T> itemEqualityComparer)
        {
            _itemEqualityComparer = itemEqualityComparer ?? EqualityComparer<T>.Default;
        }
    
        public static ListEqualityComparer<T> Default = new ListEqualityComparer<T>();
    
        public bool Equals(List<T> x, List<T> y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Count == y.Count && !x.Except(y, _itemEqualityComparer).Any();
        }
    
        public int GetHashCode(List<T> list)
        {
            int hash = 17;
            foreach (var itemHash in list.Select(x => _itemEqualityComparer.GetHashCode(x)).OrderBy(x => x))
            {
                hash += 31 * itemHash;
            }
            return hash;
        }
    }
