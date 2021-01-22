    public static class IndexedEnumerable
    {
        public static IndexedEnumerable<T> ToIndexed<T>(this IEnumerable<T> items)
        {
            return IndexedEnumerable<T>.Create(items);
        }
    }
    public class IndexedEnumerable<T> : IEnumerable<IndexedEnumerable<T>.IndexedItem>
    {
        private readonly IEnumerable<IndexedItem> _items;
        public IndexedEnumerable(IEnumerable<IndexedItem> items)
        {
            _items = items;
        }
        public class IndexedItem
        {
            public IndexedItem(int index, T value)
            {
                Index = index;
                Value = value;
            }
            public T Value { get; private set; }
            public int Index { get; private set; }
        }
        public static IndexedEnumerable<T> Create(IEnumerable<T> items)
        {
            return new IndexedEnumerable<T>(items.Select((item, index) => new IndexedItem(index, item)));
        }
        public IEnumerator<IndexedItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
