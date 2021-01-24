    static void Main(string[] args)
    {
        DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine($"There are {EachNonWorkingDay(startDate, endDate).Count()} non-working days");
    }
    private static IEnumerable<DateTime> EachNonWorkingDay(DateTime fromDate, DateTime toDate)
    {
        for (var day = fromDate.Date; day.Date <= toDate.Date; day = day.AddDays(1))
        {
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                yield return day;
            }
        }
    }
