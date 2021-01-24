    public static IQueryable<IGrouping<DateTime, TSource>> DateGroup<TSource>(this IQueryable<TSource> source, Func<TSource, DateTime> dateSelector, GraphDataTimeSpan span)
    {
        switch (span)
        {
            case GraphDataTimeSpan.Yearly:
                return source.GroupBy(e => new DateTime(dateSelector(e).Year,1,1));
            case GraphDataTimeSpan.Monthly:
                return source.GroupBy(e => new DateTime(dateSelector(e).Year,dateSelector(e).Month,1));
            case GraphDataTimeSpan.Weekly:
                // TO DO
                break;
            case GraphDataTimeSpan.Daily:
                // TO DO
                break;
        }
        return source.GroupBy(e => dateSelector(e));
    }
