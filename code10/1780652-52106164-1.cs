    private DateTime SetTimeForward(DateTime originalDate)
    {
        TimeSpan newTime = DateTime.ParseExact(FixedTime, 
                                               "hh:mm tt", 
                                               CultureInfo.InvariantCulture).TimeOfDay;
        TimeSpan diff = newTime - originalDate.TimeOfDay;
        if (diff.Ticks < 0)
            diff = diff.Add(new TimeSpan(24, 0, 0));
        return originalDate.Add(diff);
    }
