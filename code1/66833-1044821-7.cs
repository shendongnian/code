    public static DateTime AddBusinessDays(DateTime date, int days)
    {
        if (days == 0)
        {
            return date;
        }
        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            date = date.AddDays(2);
            days -= 1;
        }
        else if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            date = date.AddDays(1);
            days -= 1;
        }
        int completeWeeks = days / 5;
        int extraDays = days % 5;
        int endDay = (int)date.DayOfWeek + extraDays;
        DateTime firstGuess;
        if ((int)date.DayOfWeek + extraDays > 7)
        {
            firstGuess = date.AddDays(completeWeeks * 7 + extraDays + 2);
        }
        else
        {
            firstGuess = date.AddDays(completeWeeks * 7 + extraDays);
        }
        if (firstGuess.DayOfWeek == DayOfWeek.Saturday || firstGuess.DayOfWeek == DayOfWeek.Sunday)
        {
            return firstGuess.AddDays(2);
        }
        else
        {
            return firstGuess;
        }
    }
