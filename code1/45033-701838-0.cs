    public class SequenceEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return Enumerable.SequenceEqual(x, y);
        }
        // Probably not the best hash function for an ordered list, but it should do the job in most cases.
        public int GetHashCode(IEnumerable<T> obj)
        {
            int hash = 0;
            int i = 0;
            foreach (var element in obj)
                hash = unchecked((hash * 37 + hash) + (element.GetHashCode() << (i++ % 16)));
            return hash;
        }
    }
