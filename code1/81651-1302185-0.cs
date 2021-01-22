    public static class ProjectionComparer
    {
        public static ProjectionComparer<TSource, TKey> Create<TSource, TKey>
            (Func<TSource, TKey> projection)
        {
            return new ProjectionComparer<TSource, TKey>(projection);
        }
        public static ProjectionComparer<TSource, TKey> Create<TSource, TKey>
            (TSource ignored, Func<TSource, TKey> projection)
        {
            return new ProjectionComparer<TSource, TKey>(projection);
        }
    }
    public static class ProjectionComparer<TSource>
    {
        public static ProjectionComparer<TSource, TKey> Create<TKey>
            (Func<TSource, TKey> projection)
        {
            return new ProjectionComparer<TSource, TKey>(projection);
        }
    }
    public class ProjectionComparer<TSource, TKey> : IComparer<TSource>
    {
        readonly Func<TSource, TKey> projection;
        readonly IComparer<TKey> comparer;
        public ProjectionComparer(Func<TSource, TKey> projection)
            : this (projection, null)
        {
        }
        public ProjectionComparer(Func<TSource, TKey> projection,
                                  IComparer<TKey> comparer)
        {
            projection.ThrowIfNull("projection");
            this.comparer = comparer ?? Comparer<TKey>.Default;
            this.projection = projection;
        }
        public int Compare(TSource x, TSource y)
        {
            // Don't want to project from nullity
            if (x==null && y==null)
            {
                return 0;
            }
            if (x==null)
            {
                return -1;
            }
            if (y==null)
            {
                return 1;
            }
            return comparer.Compare(projection(x), projection(y));
        }
    }
