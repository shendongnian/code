    /* Read the initial time. */
        DateTime startTime = DateTime.Now;
        Console.WriteLine(startTime);
    
        /* Do something that takes up some time. For example sleep for 1.7 seconds. */
        Thread.Sleep(1700);
    
        /* Read the end time. */
        DateTime stopTime = DateTime.Now;
        Console.WriteLine(stopTime);
    
        /* Compute the duration between the initial and the end time. 
         * Print out the number of elapsed hours, minutes, seconds and milliseconds. */
        TimeSpan duration = stopTime - startTime;
        Console.WriteLine("hours:" + duration.Hours);
        Console.WriteLine("minutes:" + duration.Minutes);
        Console.WriteLine("seconds:" + duration.Seconds);
        Console.WriteLine("milliseconds:" + duration.Milliseconds);
