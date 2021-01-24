    private static int seed = 0;
    public static IEnumerable<int> GetSomeInts()
    {
        var rnd = new Random(seed++);
        for (int i = 0; i < 10; i++)
        {
            Console.Write(".");
            yield return rnd.Next(100000);
        }
    }
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(GetSomeInts().OrderBy(x => x).First());
    }
