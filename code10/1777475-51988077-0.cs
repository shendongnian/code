    public static class Extensions
    {
        public static void Set<T>(
            this ICollection<T> source, 
            Func<T, bool> predicate, 
            Action<T> action)
        {
            var item = source.First(predicate);
            action(item);
        }
    }
