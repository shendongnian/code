       public class GenericComparer<T> : IEqualityComparer<T>
        {
            private Func<T, object> _uniqueCheckerMethod;
    
            public GenericComparer(Func<T, object> keyPredicate)
            {
                _uniqueCheckerMethod = keyPredicate;
            }
    
            #region IEqualityComparer<T> Members
     
            bool IEqualityComparer<T>.Equals(T x, T y)
            {
                return _uniqueCheckerMethod(x).Equals(_uniqueCheckerMethod(y));
            }
    
            int IEqualityComparer<T>.GetHashCode(T obj)
            {
                return _uniqueCheckerMethod(obj).GetHashCode();
            }
    
            #endregion
        }
