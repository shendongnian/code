    /// <summary>
    /// Returns the fiscal year for the passed in date
    /// </summary>
    /// <param name="value">the date</param>
    /// <returns>the fiscal year</returns>
    public static int FiscalYear(this DateTime value)
    {
      int ret = value.Year;
      if (value.Month >= 7) ret++;
      return ret;
    }
    /// <summary>
    /// Returns the fiscal year for the passed in date
    /// </summary>
    /// <param name="value">the date</param>
    /// <returns>the fiscal year</returns>
    public static string FiscalYearString(this DateTime value)
    {
      int fy = FiscalYear(value);
      return "{0}/{1}".Format(fy - 1, fy);
    }
