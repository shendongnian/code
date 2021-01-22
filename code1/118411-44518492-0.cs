    /// <summary>
    /// Creates datetime for current century and sets days to end of month
    /// </summary>
    /// <param name="MM"></param>
    /// <param name="YY"></param>
    /// <returns></returns>
    public static DateTime GetEndOfMonth(string MM, string YY)
    {
        // YY -> YYYY #RipVanWinkle
        // Gets Current century and adds YY to it.
        // Minus 5 to allow dates that may be expired to be entered.
        // eg. today is 2017, 12 = 2012 and 11 = 2111
        int currentYear = DateTime.Now.Year;
        string thisYear = currentYear.ToString().Substring(0, 2) + YY;
        int month = Int32.Parse(MM);
        int year = Int32.Parse(thisYear);
        if ((currentYear - 5) > year)
            year += 100;
        return new DateTime(year, month, DateTime.DaysInMonth(year, month));
    }
