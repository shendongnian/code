       Stopwatch s = new Stopwatch();
        int n = 1000000;
        long fElapsedMilliseconds = 0, fElapsedTicks = 0, cElapsedMilliseconds = 0, cElapsedTicks = 0;
        Random random = new Random(DateTime.Now.Millisecond);
        string result;
        s.Start();
        for (var i = 0; i < n; i++)
            result = (random.Next().ToString() + " " + random.Next().ToString());
        s.Stop();
        cElapsedMilliseconds = s.ElapsedMilliseconds;
        cElapsedTicks = s.ElapsedTicks;
        s.Reset();
        s.Start();
        for (var i = 0; i < n; i++)
            result = string.Format("{0} {1}", random.Next().ToString(), random.Next().ToString());
        s.Stop();
        fElapsedMilliseconds = s.ElapsedMilliseconds;
        fElapsedTicks = s.ElapsedTicks;
        s.Reset();
        Console.Clear();
        Console.WriteLine(n.ToString() + " x result = string.Format(\"{0} {1}\", p.FirstName, p.LastName); took: " + (fElapsedMilliseconds) + "ms - " + (fElapsedTicks) + " ticks");
        Console.WriteLine(n.ToString() + " x result = (p.FirstName + \" \" + p.LastName); took: " + (cElapsedMilliseconds) + "ms - " + (cElapsedTicks) + " ticks");
        Console.WriteLine("****************");
        Console.WriteLine("Press Enter to Quit");
        Console.ReadLine();
