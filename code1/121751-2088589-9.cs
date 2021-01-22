    InitializeTrigonometricTables();
    Random random = new Random();
    SinOriginal(random.NextDouble());
    var sw = System.Diagnostics.Stopwatch.StartNew();
    for (long i = 0; i < 1000000000L; i++)
    {
        SinOriginal(random.NextDouble());
    }
    sw.Stop();
    Console.WriteLine("(1) {0}  // original version", sw.Elapsed);
    fixed (double* SineDoubleTable = _SineDoubleTable)
    {
        SinOptimized(SineDoubleTable, random.NextDouble());
        sw = System.Diagnostics.Stopwatch.StartNew();
        for (long i = 0; i < 1000000000L; i++)
        {
            SinOptimized(SineDoubleTable, random.NextDouble());
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
