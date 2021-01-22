    /// <summary>
    /// Converts c# DateTime object into pubdate format for RSS
    /// Desired format: Mon, 28 Mar 2011 02:51:23 -0700
    /// </summary>
    /// <param name="Date">DateTime object to parse</param>
    /// <returns>Formatted string in correct format</returns>
    public static string PubDate(DateTime Date)
    {
        string ReturnString = Date.DayOfWeek.ToString().Substring(0,3) + ", ";
        ReturnString += Date.Day + " ";
        ReturnString += CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Date.Month) + " ";
        ReturnString += Date.Year + " ";
        ReturnString += Date.TimeOfDay + " -0700";
        return ReturnString;
    }
