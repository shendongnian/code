    static void Main(string[] args)
    {
        string result = "";
        var res = "abc".Anagrams();
        Console.WriteLine(string.Join("   ", res.Where(a => a.Count() == 3).Select(a => a.MergeToStr()).TrimRight());
    }
