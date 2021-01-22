    var yourSet = yourDictionary.Values.ToHashSet();
    // ...
    public static class EnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            return new HashSet<T>(source);
        }
    }
