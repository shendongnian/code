Empty Function:       79ms   0
Original:             1576ms 0.7202294
Simplified: (soprano) 681ms  0.7202294
Approximate: (Neil)   441ms  0.7198783
Bit Manip: (martinus) 836ms  0.72318
Taylor: (Rex Logan)   261ms  0.7202305
Lookup: (Henrik)      182ms  0.7204863
    public static object[] Time(Func<double, float> f) {
        var testvalue = 0.9456;
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 1e7; i++)
            f(testvalue);
        return new object[] { sw.ElapsedMilliseconds, f(testvalue) };
    }
    public static void Main(string[] args) {
        Console.WriteLine("Empty:       {0,10}ms {1}", Time(Empty));
        Console.WriteLine("Original:    {0,10}ms {1}", Time(Original));
        Console.WriteLine("Simplified:  {0,10}ms {1}", Time(Simplified));
        Console.WriteLine("Approximate: {0,10}ms {1}", Time(ExpApproximation));
        Console.WriteLine("Bit Manip:   {0,10}ms {1}", Time(BitBashing));
        Console.WriteLine("Taylor:      {0,10}ms {1}", Time(TaylorExpansion));
        Console.WriteLine("Lookup:      {0,10}ms {1}", Time(LUT));
    }
