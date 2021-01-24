    static void Main(string[] args) 
    {
        var songs = Enumerable.Range(0, 4)
                              .Select(i => InputSongDetails())
                              .ToList();
    }
