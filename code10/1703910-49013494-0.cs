    public static decimal UsdValue = 1;
    private static readonly Random Rnd = new Random();
    private static readonly Timer Timer = new Timer(TimerCallback);
    private static void TimerCallback(object obj)
    {
        // Choose a random percentage between -20% and 76%
        var pctChange = Rnd.Next(-20, 76) / 100M;
        var plusSign = pctChange >= 0 ? "+" : "";
        // Update our value and log it to console
        UsdValue += UsdValue * pctChange;
        Console.WriteLine(
            $"{DateTime.Now}: USD value is now: {UsdValue:c} ({plusSign}{pctChange:P0})");
        // Choose a random value between 1 and 5 minutes (in milliseconds)
        var waitTime = Rnd.Next(60000, 300001);
        Console.WriteLine($"{DateTime.Now}: Next update in {waitTime / 60000} minutes.");
        Console.WriteLine(new string('-', Console.WindowWidth));
        // Change the timer interval to the new value
        Timer.Change(waitTime, Timeout.Infinite);
    }
    private static void Main()
    {
        // Start timer right away
        Timer.Change(TimeSpan.Zero, TimeSpan.Zero);
        Console.ReadKey(); // To keep console window active
    }
