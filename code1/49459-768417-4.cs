    [Test]
    public void Perf()
    {
        var testValues = new string[] {"true", "On", "test", "FaLsE", "Bogus", ""};
        var rdm = new Random();
        int RunCount = 100000;
        bool b;
        string s;
        Stopwatch sw = Stopwatch.StartNew();
        for (var i=0; i<RunCount; i++)
        {
            s = testValues[rdm.Next(0, testValues.Length - 1)];
            b = s.ToBoolean();
        }
        Console.Out.WriteLine("Method 1: {0}ms", sw.ElapsedMilliseconds);
        sw = Stopwatch.StartNew();
        for (var i = 0; i < RunCount; i++)
        {
            s = testValues[rdm.Next(0, testValues.Length - 1)];
            b = s != null ? s.ToUpperInvariant() == "ON" ? true : s.ToUpperInvariant() == "TRUE" ? true : false : false;
        }
        Console.Out.WriteLine("Method 2: {0}ms", sw.ElapsedMilliseconds);
    }
