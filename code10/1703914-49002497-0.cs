    private static void DisplayDayInfo(DateTime fromDate, DateTime toDate)
    {
        var numDays = toDate.Subtract(fromDate).Days;
        Console.WriteLine("Total number of days from {0} to {1}: {2}\n",
            fromDate.ToShortDateString(), toDate.ToShortDateString(), numDays);
        var dates = Enumerable.Range(0, numDays).Select(days => fromDate.AddDays(days));
        foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
        {
            Console.WriteLine($"{dayOfWeek}s: \t{GetDayCount(dates, dayOfWeek)}");
        }
    }
