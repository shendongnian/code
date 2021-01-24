    static void Main(string[] args)
    {
        var r = new Random();
        // generate 100000 lines of 1000 random characters
        var text = Enumerable.Range(0, 100000).Select(x => new string(Enumerable.Range(0, 1000).Select(i => (char)r.Next(255)).ToArray())).ToArray();
        // warm up
        "".CountOccurrencesSub("");
        "".CountOccurrences("");
        Measure(text, "CountOccurencesSub", s => s.CountOccurrencesSub("."));
        Measure(text, "CountOccurences", s => s.CountOccurrences("."));
        Console.ReadKey();
    }
    private static void Measure(string[] text, string test, Action<string> action)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        foreach (string s in text)
        {
            action(s);
        }
        sw.Stop();
        Console.WriteLine($"{test} Done in {sw.ElapsedMilliseconds} ms");
    }
