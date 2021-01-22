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
      var halfIntervelTicks = (long)((interval.Ticks + 1) * 0.5f);
      return dateTime.AddTicks(halfIntervelTicks - ((dateTime.Ticks + halfIntervelTicks) % interval.Ticks));
    }
