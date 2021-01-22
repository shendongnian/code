    public class MappedEqualityComparer<T,U> : EqualityComparer<T>
    {
        Func<T,U> _map;
        public MappedEqualityComparer(Func<T,U> map)
        {
            _map = map;
        }
    
        public override bool Equals(T x, T y)
        {
            return EqualityComparer<U>.Default.Equals(_map(x), _map(y));
        }
        public override int GetHashCode(T obj)
        {
            return _map(obj).GetHashCode();
        }
    }
