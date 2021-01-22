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
