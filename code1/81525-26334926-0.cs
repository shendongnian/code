    public class InlineComparer<T> : IEqualityComparer<T>
    {
        //private readonly Func<T, T, bool> equalsMethod;
        //private readonly Func<T, int> getHashCodeMethod;
        public Func<T, T, bool> EqualsMethod { get; private set; }
        public Func<T, int> GetHashCodeMethod { get; private set; }
        public InlineComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            if (equals == null) throw new ArgumentNullException("equals", "Equals parameter is required for all InlineComparer instances");
            EqualsMethod = equals;
            GetHashCodeMethod = hashCode;
        }
        public bool Equals(T x, T y)
        {
            return EqualsMethod(x, y);
        }
        public int GetHashCode(T obj)
        {
            if (GetHashCodeMethod == null) return obj.GetHashCode();
            return GetHashCodeMethod(obj);
        }
    }
