    Rate      Try-Catch          TryParse        Slowdown
      0%   00:00:00.0131758   00:00:00.0120421      0.1
     10%   00:00:00.1540251   00:00:00.0087699     16.6
     20%   00:00:00.2833266   00:00:00.0105229     25.9
     30%   00:00:00.4462866   00:00:00.0091487     47.8
     40%   00:00:00.6951060   00:00:00.0108980     62.8
     50%   00:00:00.7567745   00:00:00.0087065     85.9
     60%   00:00:00.7090449   00:00:00.0083365     84.1
     70%   00:00:00.8179365   00:00:00.0088809     91.1
     80%   00:00:00.9468898   00:00:00.0088562    105.9
     90%   00:00:01.0411393   00:00:00.0081040    127.5
    100%   00:00:01.1488157   00:00:00.0078877    144.6
    /// <param name="errorRate">Rate of errors in user input</param>
    /// <returns>Total time taken</returns>
    public static TimeSpan TimeTryCatch(double errorRate, int seed, int count)
    {
        Stopwatch stopwatch = new Stopwatch();
        Random random = new Random(seed);
        string bad_prefix = @"X";
        
        stopwatch.Start();
        for(int ii = 0; ii < count; ++ii)
        {
            string input = random.Next().ToString();
            if (random.NextDouble() < errorRate)
            {
               input = bad_prefix + input;
            }
            int value = 0;
            try
            {
                value = Int32.Parse(input);
            }
            catch(FormatException)
            {
                value = -1; // we would do something here with a logger perhaps
            }
        }
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
    /// <param name="errorRate">Rate of errors in user input</param>
    /// <returns>Total time taken</returns>
    public static TimeSpan TimeTryParse(double errorRate, int seed, int count)
    {
        Stopwatch stopwatch = new Stopwatch();
        Random random = new Random(seed);
        string bad_prefix = @"X";
        
        stopwatch.Start();
        for(int ii = 0; ii < count; ++ii)
        {
            string input = random.Next().ToString();
            if (random.NextDouble() < errorRate)
            {
               input = bad_prefix + input;
            }
            int value = 0;
            if (!Int32.TryParse(input, out value))
            {
                value = -1; // we would do something here with a logger perhaps
            }
        }
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
    public static void TimeStringParse()
    {
        double errorRate = 0.1; // 10% of the time our users mess up
        int count = 10000; // 10000 entries by a user
        
        TimeSpan trycatch = TimeTryCatch(errorRate, 1, count);
        TimeSpan tryparse = TimeTryParse(errorRate, 1, count);
        
        Console.WriteLine("trycatch: {0}", trycatch);
        Console.WriteLine("tryparse: {0}", tryparse);
    }
