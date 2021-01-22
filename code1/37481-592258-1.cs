    static public bool IsTimeOfDayBetween(DateTime time, 
                                          TimeSpan startTime, TimeSpan endTime)
    {
        if (endTime < startTime)
        {
            return time.TimeOfDay <= endTime &&
                time.TimeOfDay >= startTime;
        }
        else
        {
            return time.TimeOfDay >= startTime &&
                time.TimeOfDay <= endTime;
        }
            
    }
