    public static void Main()
    {
        // Create a timer and set a two second interval.
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 2000; // 2000ms == 2s
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        // Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = true;
        // Start the timer
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }
    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        Console.WriteLine("The interval has been elapsed");
    }
