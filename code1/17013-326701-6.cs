        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T newItem)
        {
            foreach (T item in enumerable)
            {
                yield return item;
            }
            yield return newItem;
        }
    
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, params T[] newItems)
        {
            foreach (T item in enumerable)
            {
                yield return item;
            }
            foreach (T newItem in newItems)
            {
                yield return newItem;
            }
        }
