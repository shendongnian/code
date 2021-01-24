    private static void Main()
    {
        var songs = new Song[4];
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = GetSongFromUser();
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
