    public static double GetBusinessDays(DateTime startD, DateTime endD)
    {
        while (IsWeekend(startD))
            startD = startD.Date.AddDays(1);
        while (IsWeekend(endD))
            endD = endD.Date.AddTicks(-1);
        var bussDays = (endD - startD).TotalDays -
            (2 * ((int)(endD - startD).TotalDays / 7)) -
            (startD.DayOfWeek > endD.DayOfWeek ? 2 : 0);
        return bussDays;
    }
    public static bool IsWeekend(DateTime d)
    {
        return d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday;
    }
