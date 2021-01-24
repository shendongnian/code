    private static void Main()
    {
        var songs = new Song[4];
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = GetSongFromUser();
        }
        Console.WriteLine("\nYou've entered the following songs: ");
        foreach (Song song in songs)
        {
            Console.WriteLine(song.GetDetails());
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
