    public static IEnumerable<DateTime> daysInMonth(int year, int month)
    {
        DateTime day = new DateTime(year, month, 1);
        while (day.Month == month)
        {
            yield return day;
            day = day.AddDays(1);
        }
    }
