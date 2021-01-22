    static class EnumerableExtensions {
        public struct IndexedItem<T> {
            public T Item;
            public int Index;
        }
        public static IEnumerable<IndexedItem<T>> Enumerate<T>(this IEnumerable<T> Data) {
            int i = 0;
            foreach (var x in Data)
                yield return new IndexedItem<T> { Index = i++, Item = x };           
        }
    }
