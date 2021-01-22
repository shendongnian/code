    public static class DateTimeExtensions
    {
      public static DateTime Floor(this DateTime dateTime, TimeSpan interval)
      {
        return dateTime.AddTicks(-(dateTime.Ticks % interval.Ticks));
      }
      public static DateTime Ceiling(this DateTime dateTime, TimeSpan interval)
      {
        var overflow = dateTime.Ticks % interval.Ticks;
        return overflow == 0 ? dateTime : dateTime.AddTicks(interval.Ticks - overflow);;
      }
      public static DateTime Round(this DateTime dateTime, TimeSpan interval)
      {
        var halfIntervalTicks = (interval.Ticks + 1) >> 1;
        return dateTime.AddTicks(halfIntervalTicks - ((dateTime.Ticks + halfIntervalTicks) % interval.Ticks));
      }
    }
