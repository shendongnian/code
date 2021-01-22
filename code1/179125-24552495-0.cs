    [TestMethod]
    public void IsAssignableFromVsAsPerformanceTest()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int attempts = 1000000;
        string value = "This is a test";
        for (int attempt = 0; attempt < attempts; attempt++) {
            bool isConvertible = typeof(IConvertible).IsAssignableFrom(value.GetType());
        }
        stopwatch.Stop();
        Console.WriteLine("IsAssignableFrom: {0} ms elapsed", stopwatch.ElapsedMilliseconds);
      
        stopwatch.Restart();
        for (int attempt = 0; attempt < attempts; attempt++) {
            bool isConvertible = value as string != null;
        }
        stopwatch.Stop();
        Console.WriteLine("AsOperator: {0} ms elapsed", stopwatch.ElapsedMilliseconds);
    }
