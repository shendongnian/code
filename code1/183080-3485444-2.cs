    public static class ImmutableList
    {
        public static ImmutableList<T> CreateFrom<T>(IEnumerable<T> source)
        {
            return new ImmutableList<T>(source);
        }
        public static ImmutableList<T> Create<T>(params T[] items)
        {
            return new ImmutableList<T>(items);
        }
        public static ImmutableList<T> AsImmutable<T>(this IEnumerable<T> source)
        {
            return new ImmutableList<T>(source);
        }
    }
