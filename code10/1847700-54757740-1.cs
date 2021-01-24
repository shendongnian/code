    private static void Main()
    {
        var dbStrings = new[]
        {
            "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "1.10", "1.11",
            "1.12", "1.13", "1.14", "1.15", "1.16", "1.17", "1.18", "1.19", "1.20", "2.1a(i)",
            "2.1a(ii)", "2.1a(iii)", "2.1a(iv)", "2.1a(v)", "2.1a(vi)", "2.1a(vii)"
        };
        // Custom extension method for shuffling
        dbStrings.Shuffle();
        // Select each string into our custom class
        var bandLevels = dbStrings.Select(BandLevelComponent.Parse).ToList();
        Console.WriteLine("\nShuffled List");
        Console.WriteLine(string.Join(", ", bandLevels));
        // Sort the list 
        bandLevels.Sort();
        Console.WriteLine("\nSorted List");
        Console.WriteLine(string.Join(", ", bandLevels));
        // Order the list descending (largest first)
        bandLevels = bandLevels.OrderByDescending(b => b).ToList();
        Console.WriteLine("\nOrderByDescending List");
        Console.WriteLine(string.Join(", ", bandLevels));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
