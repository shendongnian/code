    TimeSpan baseTimeSpan = new TimeSpan(1, 12, 15, 16);
          // Create an array of timespan intervals.
          TimeSpan[] intervals = { TimeSpan.FromDays(1.5), 
                                   TimeSpan.FromHours(1.5), 
                                   TimeSpan.FromMinutes(45), 
                                   TimeSpan.FromMilliseconds(505),
                                   new TimeSpan(1, 17, 32, 20), 
                                   new TimeSpan(-8, 30, 0) };
          // Calculate a new time interval by adding each element to the base interval.
          foreach (var interval in intervals)
             Console.WriteLine(@"{0,-10:g} - {3}{1,15:%d\:hh\:mm\:ss\.ffff} = {4}{2:%d\:hh\:mm\:ss\.ffff}",
                               baseTimeSpan, interval, baseTimeSpan.Subtract(interval),
                               interval < TimeSpan.Zero ? "-" : "",
                               baseTimeSpan < interval.Duration() ? "-" : "");
