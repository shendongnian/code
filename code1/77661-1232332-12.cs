    public static class Circumventions
    {
        public static IList<T> AsWritable<T>(this IEnumerable<T> source)
        {
            return source.GetType()
                .GetFields(BindingFlags.Public |
                           BindingFlags.NonPublic | 
                           BindingFlags.Instance)
                .Select(f => f.GetValue(source))
                .OfType<IList<T>>()
                .First();
        }
    }
