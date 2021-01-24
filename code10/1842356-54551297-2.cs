    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<T> list)
        {
            int hash = 17;
            foreach (var item in list)
            {
                hash += 31 * item.GetHashCode();
            }
            return hash;
        }
    }
