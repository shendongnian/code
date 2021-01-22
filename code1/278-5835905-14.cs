    public static int RoundedDays(this TimeSpan timespan)
    {
        return (timespan.Hours > 12) ? timespan.Days + 1 : timespan.Days;
    }
    public static int RoundedMonths(this TimeSpan timespan)
    {
        DateTime then = DateTime.Now - timespan;
        // Number of partial months elapsed since 1 Jan, AD 1 (DateTime.MinValue)
        int nowMonthYears = DateTime.Now.Year * 12 + DateTime.Now.Month;
        int thenMonthYears = then.Year * 12 + then.Month;                    
        return nowMonthYears - thenMonthYears;
    }
