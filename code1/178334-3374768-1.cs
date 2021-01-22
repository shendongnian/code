    static void Main(string[] args)
    {
        var total = Enumerable.Range(0,1000)
                        .Where(counter => (counter%3 == 0) || (counter%5 == 0))
                        .Sum();
        Console.WriteLine(total);
        Console.ReadKey();
    }
