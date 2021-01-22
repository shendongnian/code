    class ReferenceComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            return object.ReferenceEquals(x, y);
        }
    
        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
