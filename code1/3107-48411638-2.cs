    /// <summary>
    /// Gets the date of the first day of the week for the date.
    /// </summary>
    /// <param name="date">The date to be used</param>
    /// <param name="cultureInfo">If none is provided, the current culture is used</param>
    /// <returns>The date of the beggining of the week based on the culture specifed</returns>
    public static DateTime StartOfWeek(this DateTime date, CultureInfo cultureInfo=null) =>			
    			 date.AddDays(-1 * (7 + (date.DayOfWeek - (cultureInfo??CultureInfo.CurrentCulture).DateTimeFormat.FirstDayOfWeek)) % 7).Date;
