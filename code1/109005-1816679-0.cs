    IEnumerable<Song> GetSongOrder(List<Song> allSongs)
    {
        var playOrder = new List<Song>();
        while (true)
        {
            // this step assigns an integer weight to each song,
            // corresponding to how likely it is to be played next.
            // in a better implementation, this would look at the total number of
            // songs as well, and provide a smoother ramp up/down.
            var weights = allSongs.Select(x => playOrder.LastIndexOf(x) > playOrder.Length - 10 ? 50 : 1);
            int position = random.Next(weights.Sum());
            foreach (int i in Enumerable.Range(allSongs.Length))
            {
                position -= weights[i];
                if (position < 0)
                {
                    var song = allSongs[i];
                    playOrder.Add(song);
                    yield return song;
                    break;
                }
            }
            // trim playOrder to prevent infinite memory here as well.
            if (playOrder.Length > allSongs.Length * 10)
                playOrder = playOrder.Skip(allSongs.Length * 8).ToList();
        }    
    }
