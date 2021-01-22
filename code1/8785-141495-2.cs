    static class EnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> sequence)
        {
            foreach(var child in sequence)
                foreach(var item in child)
                    yield return item;
        }
    }
