    private static void Main()
    {
        // Pretend this is your list of songs
        var orderedListOfSongs = new List<string>
        {
            "song one",
            "song two",
            "song three",
            "song four",
            "song five",
            "song six",
            "song seven",
            "song eight",
            "song nine",
            "song ten",
        };
        // Generate a new list of ints representing the index of each song and shuffle them
        // Note: There are better ways to shuffle a list, this is just for an example
        var rnd = new Random();
        var randomizedIndexes = Enumerable.Range(0, orderedListOfSongs.Count)
            .OrderBy(i => rnd.NextDouble())
            .ToList();
        for (int i = 0; i < orderedListOfSongs.Count; i++)
        {
            Console.WriteLine($"Now playing: {orderedListOfSongs[randomizedIndexes[i]]}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
