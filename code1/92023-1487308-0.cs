    TimeSpan time1 = ...;  // assume TimeOfDay
    TimeSpan time2 = ...;  // assume TimeOfDay
    TimeSpan diffTime = time2 - time1;
    if (time2 < time1)  // crosses over midnight
        diffTime += TimeSpan.FromTicks(TimeSpan.TicksPerDay);
    int totalMilliSeconds = (int)diffTime.TotalMilliseconds;
    
