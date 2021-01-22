<!-- -->
    public static class ChainAdd
    {
        public static ICollection<T> AddItem<T>(this ICollection<T> collection, T item)
        {
            collection.Add(item);
            return collection;
        }
    }
