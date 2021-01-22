    public static DateTime getPayPeriodStartDate(DateTime givenDate, string EvenOrOdd)
    {
        DateTime newYearsDay = new DateTime(DateTime.Today.Year, 1, 1);
        DateTime firstEvenMonday = newYearsDay.AddDays((8 - (int)newYearsDay.DayOfWeek) % 7);
        DateTime firstOddMonday = firstEvenMonday.AddDays(7);
        TimeSpan span = givenDate - (EvenOrOdd.Equals("Even") ? firstEvenMonday : firstOddMonday);
        int numberOfPayPeriodsPast = span.Days / 14;
        return (EvenOrOdd.Equals("Even") ? firstEvenMonday : firstOddMonday).AddDays(14 * numberOfPayPeriodsPast);
    }
    public static List<DateTime> getPayPeriodsBetween(DateTime start, DateTime end, string EvenOrOdd)
    {
        DateTime currentPayPeriod = getPayPeriodStartDate(start, EvenOrOdd);
        if (currentPayPeriod < start) currentPayPeriod = currentPayPeriod.AddDays(14);
        List<DateTime> dtList = new List<DateTime>();
        while (currentPayPeriod <= end)
        {
            dtList.Add(currentPayPeriod);
            currentPayPeriod = currentPayPeriod.AddDays(14);
        }
        return dtList;
    }
