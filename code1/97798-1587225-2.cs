    public class NavigationItem<T>
    {
        readonly T _value;
        readonly bool _isFirst, _isLast, _isEven;
        internal NavigationItem(T value, bool isFirst, bool isLast, bool isEven)
        {
            _value = value;
            _isFirst = isFirst;
            _isLast = isLast;
            _isEven = isEven;
        }
        public T Value { get { return _value; } }
        public bool IsFirst { get { return _isFirst; } }
        public bool IsLast { get { return _isLast; } }
        public bool IsEven { get { return _isEven; } }
        public bool IsOdd { get { return !_isEven; } }
    }
    public static class CollectionNavigation
    {
        public IEnumerable<NavigationItem<T>> ToNavigable<T>(this IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            return ToNavigableCore(collection);
        }
        private IEnumerable<NavigationItem<T>> ToNavigableCore<T>(IEnumerable<T> collection)
        {
            using(var enumerator = collection.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    T current = enumerator.Current;
                    bool isFirst = true, isEven = true;
                    while(enumerator.MoveNext())
                    {
                        yield return new NavigationItem<T>(current, isFirst, false, isEven);
                        isFirst = false;
                        isEven = !isEven;
                        current = enumerator.Current;
                    }
                    yield return new NavigationItem<T>(current, isFirst, true, isEven);
                }
            }
        }
    }
