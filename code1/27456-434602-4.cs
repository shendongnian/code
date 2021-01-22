    public static class QueryExtension
    {
        public static IQueryable<TProjection>
            Get<TSource, TProjection, TOrderKey>(
                this IQueryable<TSource> source,
                Expression<Func<TSource, bool>> where, // optional
                Expression<Func<TSource, TProjection>> select,
                Expression<Func<TProjection, TOrderKey>> orderBy)
        {
            if (where != null) source = source.Where(where);
            return source.Select(select).OrderBy(orderBy);
        }
    }
