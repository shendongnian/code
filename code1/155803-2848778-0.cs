    public static IEnumerable<DateTime> GetFirstWeek(int year, int month) {
        DateTime firstDay = new DateTime(year, month, 1);
        firstDay = firstDay.AddDays(-(int) firstDay.DayOfWeek);
        for (int i = 0; i < 7; ++i)
            yield return firstDay.AddDays(i);
    }
