    public static class TimeSpanExtensions
    {
       public static TimeSpan Sum(this IEnumerable<TimeSpan> source)
          => TimeSpan.FromTicks(source.Sum(t => t.Ticks));
    }
