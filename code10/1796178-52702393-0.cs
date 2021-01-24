    static void Main(string[] args)
    {
        var target = DateTime.Now.AddMinutes(1);
        var delay = (target - DateTime.Now).TotalMilliseconds;
        var aTimer = new System.Timers.Timer(delay);
        aTimer.Elapsed += (s, e) => { Console.Beep(); };
        aTimer.Enabled = true;
        Console.WriteLine("Wait a minute...");
        // time to do something useful
        Console.ReadLine();
    }
