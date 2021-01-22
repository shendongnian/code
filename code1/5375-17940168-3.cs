    System.Diagnostics.Stopwatch time = new Stopwatch();
    string test = string.Empty;
    time.Start();
    for (int i = 0; i < 100000; i++)
    {
        test += i;
    }
    time.Stop();
    System.Console.WriteLine("Using String concatenation: " + time.ElapsedMilliseconds + " milliseconds");
