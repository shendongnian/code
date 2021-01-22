    static partial class Extensions
    {
        public static T WhereMax<T, U>(this IEnumerable<T> items, Func<T, U> selector)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Empty input sequence");
            }
            var comparer = Comparer<U>.Default;
            T   maxItem  = items.First();
            U   maxValue = selector(maxItem);
            foreach (T item in items.Skip(1))
            {
                // Get the value of the item and compare it to the current max.
                U value = selector(item);
                if (comparer.Compare(value, maxValue) > 0)
                {
                    maxValue = value;
                    maxItem  = item;
                }
            }
            return maxItem;
        }
    }
