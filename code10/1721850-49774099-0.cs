    private static DateTime start;
    private static void SetTimer()
    {
        //
        // set the start time
        //
        start = DateTime.Now;
        ...
    }
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        //
        // calculate the time spent
        //
        TimeSpan spent = DateTime.Now - start;
        Console.WriteLine($"The Elapsed event was raised at {spent.Hours}:{spent.Minutes:D2}:{spent.Seconds:D2}:{spent.Milliseconds:D3}");
    }
