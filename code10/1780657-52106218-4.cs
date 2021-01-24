    static DateTime GetClosingTime(DateTime fixedTime, DateTime dbTime)
    {
        var cutoff = new DateTime(dbTime.Year, dbTime.Month, dbTime.Day, fixedTime.Hour, fixedTime.Minute, fixedTime.Second);
        return dbTime < cutoff ? cutoff : cutoff.AddDays(1);
    }
