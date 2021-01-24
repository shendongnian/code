    var timer2 = new Timer();
    timer2.Elapsed += (o, e) =>
    {
        Console.WriteLine("Time Elapsed {0}", e.SignalTime);
        timer2.Stop();
    };
    timer2.Interval = 1000;
    timer2.Start();
