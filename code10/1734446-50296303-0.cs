    private static void Main()
    {
        for (int i = 0; i < 10000; i++) ListOfElements.Add(new Element());
        // Create a randomly-ordered list of indexes to choose from
        var rnd = new Random();
        var randomIndexes = Enumerable.Range(0, ListOfElements.Count)
            .OrderBy(i => rnd.NextDouble()).ToList();
        // Now use our random indexes to pull unique items from the Element list
        for (int i = 0; i < 10000; i += 2)
            ListOfLinks.Add(new Link(ListOfElements[randomIndexes[i]].Id,
                ListOfElements[randomIndexes[i + 1]].Id));
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
