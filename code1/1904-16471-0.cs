        System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
        
        var p = new { FirstName = "Bill", LastName = "Gates" };
        s.Start();
        Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
        s.Stop();
        Console.WriteLine("Console.WriteLine(\"{0} {1}\", p.FirstName, p.LastName); took: " + s.ElapsedMilliseconds + "ms - " + s.ElapsedTicks + " ticks");
        s.Reset();
        s.Start();
        Console.WriteLine(p.FirstName + " " + p.LastName);
        s.Stop();
        Console.WriteLine("Console.WriteLine(p.FirstName + \" \" + p.LastName); took: " + s.ElapsedMilliseconds + "ms - " + s.ElapsedTicks + " ticks");
