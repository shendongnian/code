    private static void Main()
    {
        var gardenvlist = new List<string> {"Garden One", "Garden Two"};
        var oceanvlist = new List<string> {"Ocean One", "Ocean Two", "Ocean Three"};
        var cityvlist = new List<string> {"City One", "City Two"};
        int days = 2;
        var allValidItems = new List<string>();
        if (gardenvlist.Count == days)
        {
            allValidItems.AddRange(gardenvlist);
        }
        if (oceanvlist.Count == days)
        {
            allValidItems.AddRange(oceanvlist);
        }
        if (cityvlist.Count == days)
        {
            allValidItems.AddRange(cityvlist);
        }
        foreach (var validItem in allValidItems)
        {
            Console.WriteLine(validItem);
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
