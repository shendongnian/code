    public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
    {
        return TimeSpan.FromTicks(times.Sum(t => t.Ticks));
    }
    public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source,
        Func<TSource, TimeSpan> selector)
    {
        return TimeSpan.FromTicks(source.Sum(t => selector(t).Ticks));
    }
