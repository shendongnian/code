    int IntervalParameter = 5;
      
    // .Range(0, 1440 / IntervalParameter) 
    // is brief, but less readable
    List<string> query = Enumerable
      .Range(0, (int) (new TimeSpan(24, 0, 0).TotalMinutes / IntervalParameter))
      .Select(i => DateTime.Today
         .AddMinutes(i * (double)IntervalParameter) // AddHours is redundant
         .ToString("HH:mm"))                        // Let's provide HH:mm format 
      .ToList();
