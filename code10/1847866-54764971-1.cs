    private DateTime MyRoundTime(DateTime date)
    {
      TimeSpan roundMins = TimeSpan.FromMinutes(15);
      date += TimeSpan.FromMinutes(2.5);
      return new DateTime(((date.Ticks + (roundMins.Ticks - 1)/2) / roundMins.Ticks) * roundMins.Ticks);
    }
