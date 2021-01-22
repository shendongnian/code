PeriodBetween(#2/28/2011#, DateTime.UtcNow, 6)
Main Method:
public static string PeriodBetween(DateTime then, DateTime now, byte numberOfPeriodUnits = 2)
{
    // Translated from VB.Net to C# from: https://stackoverflow.com/a/1956265
    // numberOfPeriodUnits identifies how many time period units to show.
    // If numberOfPeriodUnits = 3, function would return:
    //      "3 years, 2 months and 13 days"
    // If numberOfPeriodUnits = 2, function would return:
    //      "3 years and 2 months"
    // If numberOfPeriodUnits = 6, (maximum value), function would return:
    //      "3 years, 2 months, 13 days, 13 hours, 29 minutes and 9 seconds"
    if (numberOfPeriodUnits > 6 || numberOfPeriodUnits < 1)
    {
        throw new ArgumentOutOfRangeException($"Parameter [{nameof(numberOfPeriodUnits)}] is out of bounds. Valid range is 1 to 6.");
    }
    short Years = 0;
    short Months = 0;
    short Days = 0;
    short Hours = 0;
    short Minutes = 0;
    short Seconds = 0;
    short DaysInBaseMonth = (short)(DateTime.DaysInMonth(then.Year, then.Month));
    Years = (short)(now.Year - then.Year);
    Months = (short)(now.Month - then.Month);
    if (Months < 0)
    {
        Months += 12;
        Years--; // add 1 year to months, and remove 1 year from years.
    }
    Days = (short)(now.Day - then.Day);
    if (Days < 0)
    {
        Days += DaysInBaseMonth;
        Months--;
    }
    Hours = (short)(now.Hour - then.Hour);
    if (Hours < 0)
    {
        Hours += 24;
        Days--;
    }
    Minutes = (short)(now.Minute - then.Minute);
    if (Minutes < 0)
    {
        Minutes += 60;
        Hours--;
    }
    Seconds = (short)(now.Second - then.Second);
    if (Seconds < 0)
    {
        Seconds += 60;
        Minutes--;
    }
    // This is the display functionality.
    StringBuilder sb = new StringBuilder();
    short NumberOfPeriodUnitsAdded = 0;
    if (Years > 0)
    {
        sb.Append(Years);
        sb.Append(" year" + (Years != 1 ? "s" : "") + ", ");
        NumberOfPeriodUnitsAdded++;
    }
    if (numberOfPeriodUnits == NumberOfPeriodUnitsAdded)
    {
        goto ParseAndReturn;
    }
    if (Months > 0)
    {
        sb.AppendFormat(Months.ToString());
        sb.Append(" month" + (Months != 1 ? "s" : "") + ", ");
        NumberOfPeriodUnitsAdded++;
    }
    if (numberOfPeriodUnits == NumberOfPeriodUnitsAdded)
    {
        goto ParseAndReturn;
    }
    if (Days > 0)
    {
        sb.Append(Days);
        sb.Append(" day" + (Days != 1 ? "s" : "") + ", ");
        NumberOfPeriodUnitsAdded++;
    }
    if (numberOfPeriodUnits == NumberOfPeriodUnitsAdded)
    {
        goto ParseAndReturn;
    }
    if (Hours > 0)
    {
        sb.Append(Hours);
        sb.Append(" hour" + (Hours != 1 ? "s" : "") + ", ");
        NumberOfPeriodUnitsAdded++;
    }
    if (numberOfPeriodUnits == NumberOfPeriodUnitsAdded)
    {
        goto ParseAndReturn;
    }
    if (Minutes > 0)
    {
        sb.Append(Minutes);
        sb.Append(" minute" + (Minutes != 1 ? "s" : "") + ", ");
        NumberOfPeriodUnitsAdded++;
    }
    if (numberOfPeriodUnits == NumberOfPeriodUnitsAdded)
    {
        goto ParseAndReturn;
    }
    if (Seconds > 0)
    {
        sb.Append(Seconds);
        sb.Append(" second" + (Seconds != 1 ? "s" : "") + "");
        NumberOfPeriodUnitsAdded++;
    }
    ParseAndReturn:
    // If the string is empty, that means the datetime is less than a second in the past.
    // An empty string being passed will cause an error, so we construct our own meaningful
    // string which will still fit into the "Posted * ago " syntax.
    if (sb.ToString() == "")
    {
        sb.Append("less than 1 second");
    }
    return sb.ToString().TrimEnd(' ', ',').ToString().ReplaceLast(",", " and");
}
ReplaceLast Extension Method:
public static string ReplaceLast(this string source, string search, string replace)
{
    int pos = source.LastIndexOf(search);
    if (pos == -1)
    {
        return source;
    }
    return source.Remove(pos, search.Length).Insert(pos, replace);
}
