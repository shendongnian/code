    static void Main(string[] args)
    {
        var timeMS = 1000;
        var timer = new Timer(_ => Console.WriteLine("Peekaboo"), null, timeMS, Timeout.Infinite);
        Console.ReadKey();
    }
