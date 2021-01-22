    InitializeTrigonometricTables();
    CalcOriginal(-23698.0d);
    var sw = System.Diagnostics.Stopwatch.StartNew();
    for (long i = 0; i < 1000000000L; i++)
    {
        CalcOriginal(-23698.0d);
    }
    sw.Stop();
    Console.WriteLine("(1) {0}", sw.Elapsed);
    fixed (double* SineDoubleTable = _SineDoubleTable)
    {
        CalcOptimized(SineDoubleTable, -23698.0d);
        sw = System.Diagnostics.Stopwatch.StartNew();
        for (long i = 0; i < 1000000000L; i++)
        {
            CalcOptimized(SineDoubleTable, -23698.0d);
        }
        sw.Stop();
        Console.WriteLine("(2) {0}", sw.Elapsed);
    }
    Math.Sin(-23698.0d);
    sw = System.Diagnostics.Stopwatch.StartNew();
    for (long i = 0; i < 1000000000L; i++)
    {
        Math.Sin(-23698.0d);
    }
    sw.Stop();
    Console.WriteLine("(3) {0}", sw.Elapsed);
