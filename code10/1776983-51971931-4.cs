    /// <summary>
    /// Returns a custom date string, like "22nd day of August 2018"
    /// </summary>
    /// <param name="date">The date to use</param>
    /// <returns>The custom formatted date string</returns>
    private static string GetCustomDateString(DateTime date)
    {
        return $"{GetNumberWithOrdinalIndicator(date.Day)} day of {date.ToString("MMMM yyyy")}";
    }
