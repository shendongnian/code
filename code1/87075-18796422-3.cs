    private static DateTime Floor(DateTime dateTime, TimeSpan interval)
    {
      return dateTime.AddTicks(-(dateTime.Ticks % interval.Ticks));
    }
    private static DateTime Ceiling(DateTime dateTime, TimeSpan interval)
    {
      return dateTime.AddTicks(interval.Ticks - (dateTime.Ticks % interval.Ticks));
    }
    private static DateTime Round(DateTime dateTime, TimeSpan interval)
    {
      var halfIntervelTicks = (interval.Ticks + 1) >> 1;
      return dateTime.AddTicks(halfIntervelTicks - ((dateTime.Ticks + halfIntervelTicks) % interval.Ticks));
    }
