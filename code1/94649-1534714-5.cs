    public static bool WithinPreviousPeriod(this DateTime dt, int daysBack)
    {
         return dt.Date > DateTime.Today.AddDays(-daysBack))
                 && dt < DateTime.Now;
    }
