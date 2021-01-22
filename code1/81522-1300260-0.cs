    /// <summary>
    /// A class to wrap the IEqualityComparer interface into matching functions for simple implementation
    /// </summary>
    /// <typeparam name="T">The type of object to be compared</typeparam>
    public class MyIEqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Create a new comparer based on the given Equals and GetHashCode methods
        /// </summary>
        /// <param name="equals">The method to compute equals of two T instances</param>
        /// <param name="getHashCode">The method to compute a hashcode for a T instance</param>
        public MyIEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            if (equals == null)
                throw new ArgumentNullException("equals", "Equals parameter is required for all MyIEqualityComparer instances");
            EqualsMethod = equals;
            GetHashCodeMethod = getHashCode;
        }
        /// <summary>
        /// Gets the method used to compute equals
        /// </summary>
        public Func<T, T, bool> EqualsMethod { get; private set; }
        /// <summary>
        /// Gets the method used to compute a hash code
        /// </summary>
        public Func<T, int> GetHashCodeMethod { get; private set; }
        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            return EqualsMethod(x, y);
        }
        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            if (GetHashCodeMethod == null)
                return obj.GetHashCode();
            return GetHashCodeMethod(obj);
        }
    }
