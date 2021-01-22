    System.Timers.Timer aTimer;
    public static void Main()
    {
        // Create a timer with a ten second interval.
        aTimer = new System.Timers.Timer(10000);
        // Hook up the Elapsed event for the timer.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        // Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 2000;
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program.");
        Console.ReadLine();
    }
    // Specify what you want to happen when the Elapsed event is 
    // raised.
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
