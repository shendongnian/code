    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        private IEqualityComparer<T> _itemEqualityComparer = EqualityComparer<T>.Default;
    
        public ListEqualityComparer() { }
    
        public ListEqualityComparer(IEqualityComparer<T> itemEqualityComparer)
        {
            _itemEqualityComparer = itemEqualityComparer ?? EqualityComparer<T>.Default;
        }
    
        public static ListEqualityComparer<T> Default = new ListEqualityComparer<T>();
    
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y, _itemEqualityComparer);
        }
    
        public int GetHashCode(List<T> list)
        {
            int hash = 17;
            foreach (var item in list)
            {
                hash += 31 * _itemEqualityComparer.GetHashCode(item);
            }
            return hash;
        }
    }
