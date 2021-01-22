    public static class FrameworkExtensions
    {
        // a map function
        public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
        {
            foreach (var item in @enum) mapFunction(item);
        }
    }
