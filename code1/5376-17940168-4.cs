    StringBuilder test1 = new StringBuilder();
    time.Reset();
    time.Start();
    for (int i = 0; i < 100000; i++)
    {
        test1.Append(i);
    }
    time.Stop();
    System.Console.WriteLine("Using StringBuilder: " + time.ElapsedMilliseconds + " milliseconds");
