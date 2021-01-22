    TimeSpan start = TimeSpan.Parse("22:00");  // 10 PM
    TimeSpan end = TimeSpan.Parse("02:00");    // 2 AM
    TimeSpan now = DateTime.Now.TimeOfDay;
    bool bMatched = now.TimeOfDay >= start.TimeOfDay &&
                    now.TimeOfDay < end.TimeOfDay;
    // Handle the boundary case of switching the day across mid-night
    if (end < start)
        bMatched = !bMatched;
    if(bMatched)
    {
        // match found, current time is between start and end
    }
    else
    {
        // otherwise ... 
    }
