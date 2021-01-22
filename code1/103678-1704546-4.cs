    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> col, Action<T> itemWorker)
        {
            foreach (var item in col)
            {
                itemWorker(item);
            }
        }
    }
