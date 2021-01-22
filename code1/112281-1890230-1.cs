    /// <summary>
    /// A generic object comparerer that would only use object's reference, 
    /// ignoring any <see cref="IEquatable{T}"/> or <see cref="object.Equals(object)"/>  overrides.
    /// </summary>
    public class ObjectReferenceEqualityComparerer<T> : IEqualityComparer<T>
        where T : class
    {
        private static IEqualityComparer<T> _defaultComparer;
        public static IEqualityComparer<T> Default
        {
            get { return _defaultComparer ?? (_defaultComparer = new ObjectReferenceEqualityComparerer<T>()); }
        }
        #region IEqualityComparer<T> Members
        public bool Equals(T x, T y)
        {
            return ReferenceEquals(x, y);
        }
        public int GetHashCode(T obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
        #endregion
    }
