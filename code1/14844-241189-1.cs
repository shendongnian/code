    static void PrintHowLong(DateTime a, DateTime b)
    {
        TimeSpan span = a - b;
        Console.WriteLine(span.Seconds);        // WRONG!
        Console.WriteLine(span.TotalSeconds);   // RIGHT!
    }
