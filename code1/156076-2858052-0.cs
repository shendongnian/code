    System.TimeSpan span = dates[0] - dates[1]; 
    int days = Math.Abs((int)span.TotalDays);
    
    if (days > 10)
    {
        throw new Exception("Over 10 days");
    }
