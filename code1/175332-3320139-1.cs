    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> seq, Action<T> action)
        {
            foreach (var item in seq)
            {
                action(item);
            }
        }
    }
