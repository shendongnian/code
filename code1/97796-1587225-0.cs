    public class NavigationItem<T>
    {
        readonly T _value;
        readonly bool _isFirst, _isLast, _isEven;
        internal NavigationItem(T value, bool isFirst, bool isLast, bool isEven)
        {
            _value = value;
            _isFirst = isFirst;
            _isLast = isLast;
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
            using(var lEnumerator = collection.GetEnumerator())
            {
                if (lEnumerator.MoveNext())
                {
                    T lCurrent = lEnumerator.Current;
                    bool lIsFirst = true, lIsEven = true;
                    while(lEnumerator.MoveNext())
                    {
                        yield return new NavigationItem<T>(lCurrent, lIsFirst, false, lIsEven);
                        lIsFirst = false;
                        lIsEven = !lIsEven;
                        lCurrent = lEnumerator.Current;
                    }
                    yield return new NavigationItem<T>(lCurrent, lIsFirst, true, lIsEven);
                }
            }
        }
    }
