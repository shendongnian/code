    private static void Main(string[] args)
    {
        var someEvents = Enumerable
            .Range(1, 10)
            .Select(_ => CreateSample())
            .ToList();
        foreach (var item in someEvents)
        {
            Console.WriteLine(item);
        }
        // Here we calculate the sum, by using .Aggregate()
        var all = someEvents.Aggregate(TimeSpan.Zero, (sum, item) => sum + item.CalculateDuration());
        Console.WriteLine(all);
        Console.WriteLine("Finished");
        Console.ReadKey();
    }
