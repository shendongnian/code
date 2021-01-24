    public static class KeyComparer
    {
        public static KeyComparer<TSource, TKey> Create<TSource, TKey>(
            Func<TSource, TKey> keySelector,
            IComparer<TKey> innerComparer = null)
        {
            return new KeyComparer<TSource, TKey>(keySelector, innerComparer);
        }
    }
    public class KeyComparer<TSource, TKey> : Comparer<TSource>
    {
        protected internal KeyComparer(
            Func<TSource, TKey> keySelector,
            IComparer<TKey> innerComparer = null)
        {
            KeySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
            InnerComparer = innerComparer ?? Comparer<TKey>.Default;
        }
        public Func<TSource, TKey> KeySelector { get; }
        public IComparer<TKey> InnerComparer { get; }
        public override int Compare(TSource x, TSource y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            TKey xKey = KeySelector(x);
            TKey yKey = KeySelector(y);
            return InnerComparer.Compare(xKey, yKey);
        }
    }
