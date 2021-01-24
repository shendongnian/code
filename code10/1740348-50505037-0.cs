    var appointmentStartTimes = new List<string>();
    //fill values here 
    
    var appointmentStartTimesConverted = appointmentStartTimes
        .Select(i =>
            {
                try
                {
                    return TimeSpan.Parse(i);
                }
                catch
                {
                    return default(TimeSpan);
                }
            }
        ).ToList();
    
    //anothey way
    appointmentStartTimesConverted = appointmentStartTimes
        .Select(i =>
            {
                if (TimeSpan.TryParse(i, out var result))
                    return result;
    
                return default(TimeSpan);
            }
        ).ToList();
