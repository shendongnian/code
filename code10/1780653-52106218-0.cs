    static DateTime GetClosingTime(DateTime fixedTime, DateTime dbTime)
    {
        var cutoff = new DateTime(dbTime.Year, dbTime.Month, dbTime.Day, fixedTime.Hour, fixedTime.Minute, fixedTime.Second);
        if (dbTime < cutoff)
            return cutoff;
        else
        {
            cutoff = cutoff.AddDays(1);
            return cutoff;
        }
    }
