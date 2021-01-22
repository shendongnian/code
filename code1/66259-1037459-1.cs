    /// <returns>Returns all dates in logString as List<string><returns>
    public static List<string> GetMatchedDates(String logString)
    {
        List<string> dateList = new List<string>();
        Regex r;
        // Matches all the data between the quotes inside var matches
        r = new Regex(@"(\d{2}|\d{4}){1}/\d{2}(/\d{2}|\d{4})*", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
        for (Match m = r.Match(logString); m.Success; m = m.NextMatch())
        {
            dateList.Add(m.Value);
        }
    
        return dateList;
    }
