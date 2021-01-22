      return Timer.FirstDateOfWeekOfMonth(year, 1, weekOfYear);
    }
    public static DateTime FirstDateOfWeekOfMonth(int year, int month, int weekOfYear)
    {
      DateTime dtFirstDayOfMonth = new DateTime(year, month, 1);
