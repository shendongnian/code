    public class DelegateComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _equals;
        private Func<T, int> _hashCode;
        public DelegateComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            _equals= equals;
            _hashCode = hashCode;
        }
        public bool Equals(T x, T y)
        {
            return _equals(x, y);
        }
        public int GetHashCode(T obj)
        {
            if(_hashCode!=null)
                return _hashCode(obj);
            return obj.GetHashCode();
        }       
    }
    public static class Extensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items, 
            Func<T, T, bool> equals, Func<T,int> hashCode)
        {
            return items.Distinct(new DelegateComparer<T>(equals, hashCode));    
        }
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items,
            Func<T, T, bool> equals)
        {
            return items.Distinct(new DelegateComparer<T>(equals,null));
        }
    }
    var uniqueItems=students.Select(s=> new {FirstName=s.FirstName, LastName=s.LastName})
                .Distinct((a,b) => a.FirstName==b.FirstName, c => c.FirstName.GetHashCode()).ToList();
