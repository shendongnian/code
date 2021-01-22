    Stopwatch s = new Stopwatch();
    var p = new { FirstName = "Bill", LastName = "Gates" };
    //First print to remove the initial cost
    Console.WriteLine(p.FirstName + " " + p.LastName);
    Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
    int n = 100000;
    long fElapsedMilliseconds = 0, fElapsedTicks = 0, cElapsedMilliseconds = 0, cElapsedTicks = 0;
    for (var i = 0; i < n; i++)
    {
        s.Start();
        Console.WriteLine(p.FirstName + " " + p.LastName);
        s.Stop();
        cElapsedMilliseconds += s.ElapsedMilliseconds;
        cElapsedTicks += s.ElapsedTicks;
        s.Reset();
        s.Start();
        Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
        s.Stop();
        fElapsedMilliseconds += s.ElapsedMilliseconds;
        fElapsedTicks += s.ElapsedTicks;
        s.Reset();
    }
    Console.Clear();
    Console.WriteLine("Console.WriteLine(\"{0} {1}\", p.FirstName, p.LastName); took (avg): " + (fElapsedMilliseconds / n) + "ms - " + (fElapsedTicks / n) + " ticks");
    Console.WriteLine("Console.WriteLine(p.FirstName + \" \" + p.LastName); took (avg): " + (cElapsedMilliseconds / n) + "ms - " + (cElapsedTicks / n) + " ticks");
