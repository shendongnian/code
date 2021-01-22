    InitializeTrigonometricTables();
    Random random = new Random();
    CalcOriginal(random.NextDouble());
    var sw = System.Diagnostics.Stopwatch.StartNew();
    for (long i = 0; i < 1000000000L; i++)
    {
        CalcOriginal(random.NextDouble());
    }
    sw.Stop();
    Console.WriteLine("(1) {0}  // original code", sw.Elapsed);
    fixed (double* SineDoubleTable = _SineDoubleTable)
    {
        CalcOptimized(SineDoubleTable, random.NextDouble());
        sw = System.Diagnostics.Stopwatch.StartNew();
        for (long i = 0; i < 1000000000L; i++)
        {
            CalcOptimized(SineDoubleTable, random.NextDouble());
        }
        sw.Stop();
        Console.WriteLine("(2) {0}  // optimized version", sw.Elapsed);
    }
    Math.Sin(random.NextDouble());
    sw = System.Diagnostics.Stopwatch.StartNew();
    for (long i = 0; i < 1000000000L; i++)
    {
        Math.Sin(random.NextDouble());
    }
    sw.Stop();
    Console.WriteLine("(3) {0}  // Math.Sin", sw.Elapsed);
