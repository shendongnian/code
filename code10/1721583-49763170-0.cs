    public static class Ext
    {
        public static void Foreach<T>(this IEnumerable<T> e, Action<T> action)
        {
            foreach (T item in e)
            {
                action(item);
            }
        }
    }
