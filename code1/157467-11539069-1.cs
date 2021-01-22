    public long GetTime()
    {
        DateTime dtCurTime = DateTime.Now.ToUniversalTime();
        DateTime dtEpochStartTime = Convert.ToDateTime("1/1/1970 0:00:00 AM");
        TimeSpan ts = dtCurTime.Subtract(dtEpochStartTime);
        double epochtime;
        epochtime = ((((((ts.Days * 24) + ts.Hours) * 60) + ts.Minutes) * 60) + ts.Seconds);   
        return Convert.ToInt64(epochtime);
    }
