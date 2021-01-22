    public static double GetBusinessDays(DateTime startD, DateTime endD)
    {
        double calcBusinessDays =
            1 + ((endD - startD).TotalDays * 5 -
            (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;
        if ((int)endD.DayOfWeek == 6) calcBusinessDays--;
        if ((int)startD.DayOfWeek == 0) calcBusinessDays--;
        return calcBusinessDays;
    }
