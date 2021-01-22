    public static class MyExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
           foreach (var item in list) action(item);
        } 
    }
