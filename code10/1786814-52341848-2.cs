    public class GenericComparer<T> : IEqualityComparer<T> where T : class
    {
        private readonly Func<T, object> _identitySelector;
        public GenericComparer(Func<T, object> identitySelector)
        {
            _identitySelector = identitySelector;
        }
        public bool Equals(T x, T y)
        {
            var first = _identitySelector.Invoke(x);
            var second = _identitySelector.Invoke(y);
            return first != null && first.Equals(second);
        }
        public int GetHashCode(T obj)
        {
            return _identitySelector.Invoke(obj).GetHashCode();
        }
    }
    public bool CompareFoo2(Foo a, Foo b, params IEqualityComparer<Foo>[] comparers)
    {
        foreach (var comparer in comparers)
        {
            if (!comparer.Equals(a, b))
            {
                return false;
            }
        }
        return true;
    }
