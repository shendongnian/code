    /// <summary>
    /// Rounds a DateTime to the nearest hour.
    /// </summary>
    /// <param name="dateTime">DateTime to Round</param>
    /// <returns>DateTime rounded to nearest hour</returns>
    public static DateTime RoundToNearestHour(this DateTime dateTime)
    {
      dateTime += TimeSpan.FromMinutes(30);
      
      return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
    }
