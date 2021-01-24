    private static readonly HashSet<string> Names = new HashSet<string> { "Name1", "Name10", "Name3", "Name2" };
    static void Main(string[] args)
    {
        int index = Enumerable.Range(1, 255).FirstOrDefault(i => !IsNameAvailable(i));
        Console.WriteLine($"First non available name: Name{index}");
        Console.Read();
    }
    private static bool IsNameAvailable(int index)
    {
        return Names.Contains($"Name{index}");
    }
