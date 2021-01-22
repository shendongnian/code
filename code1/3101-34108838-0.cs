    //ToDo: Need to provide cultraly neutral versions.
    public static DateTime GetStartOfWeek(this DateTime dt)
    {
      DateTime ndt = dt.Subtract(TimeSpan.FromDays((int)dt.DayOfWeek));
      return new DateTime(ndt.Year, ndt.Month, ndt.Day, 0, 0, 0, 0);
    }
    public static DateTime GetEndOfWeek(this DateTime dt)
    {
      DateTime ndt = dt.GetStartOfWeek().AddDays(6);
      return new DateTime(ndt.Year, ndt.Month, ndt.Day, 23, 59, 59, 999);
    }
    public static  DateTime GetStartOfWeek(this DateTime dt, int year, int week)
    {
      DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
      return dayInWeek.GetStartOfWeek();
    }
    public static DateTime GetEndOfWeek(this DateTime dt, int year, int week)
    {
      DateTime dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
      return dayInWeek.GetEndOfWeek();
    }
  }
}
