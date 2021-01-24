    private static void Main()
    {
        var names = new List<string> {"bob", "alice", "curt"};
        foreach (var nameVariations in GetNameVariations(names))
        {
            Console.WriteLine(string.Join(", ", nameVariations));
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
