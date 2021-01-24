    public static class Groupings
    {
        public static IGrouping<TKey, TElement> FilterElements(
            this IGrouping<TKey, TValue> grouping,
            Func<TValue, bool> predicate) =>
            new LateGrouping<TKey, TValue>(grouping.Key, grouping.Where(predicate));
    }
    internal class LateGrouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        public TKey Key { get; }
        private readonly IEnumerable<TElement> elements;
        public LateGrouping(TKey key, IEnumerable<TElement> elements)
        {
            Key = key;
            this.elements = elements;
        }
        public IEnumerator<TElement> GetEnumerator() => elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
