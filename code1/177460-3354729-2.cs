    static void Main(string[] args)
    {
        var lst = GenerateStrings().Take(5000000).ToList();
        var hsh = new HashSet<string>(lst);
        var found = false;
        var count = 100;
        var sw = Stopwatch.StartNew();
    
        for (int i = 0; i < count; i++)
        {
            hsh = new HashSet<string>(lst);
        }
        Console.WriteLine(TimeSpan.FromTicks(sw.ElapsedTicks / count));
                
        sw = Stopwatch.StartNew();
        for (int i = 0; i < count; i++)
        {
            found = lst.Contains("12345678");
        }
        Console.WriteLine(TimeSpan.FromTicks(sw.ElapsedTicks / count));
    
        sw = Stopwatch.StartNew();
        for (int i = 0; i < count; i++)
        {
            found = hsh.Contains("12345678");
        }
        Console.WriteLine(TimeSpan.FromTicks(sw.ElapsedTicks / count));
    
        Console.WriteLine(found);
        Console.ReadLine();
    }
    
    private static IEnumerable<string> GenerateStrings()
    {
        var rnd = new Random();
        while (true)
        {
            yield return rnd.Next().ToString();
        }
    }
