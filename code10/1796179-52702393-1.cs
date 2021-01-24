    static void Main(string[] args)
    {
        var target = DateTime.Now.AddMinutes(1);  // test data
        var aTimer = new System.Timers.Timer((target - DateTime.Now).TotalMilliseconds);
        aTimer.Elapsed += (s, e) => { Console.Beep(); };
        aTimer.Enabled = true;
        Console.WriteLine("Wait a minute...");
        // time to do something useful
        Console.ReadLine();
    }
