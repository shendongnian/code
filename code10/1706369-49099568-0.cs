    foreach (var item in model.Albums)
    {
        foreach (var song in model.PlaylistSongs)
        {
            model.Songs = item.Songs.Where(x => x.SongID == song.SongID).ToList();
            foreach (var single in model.Songs)
            {
                System.Diagnostics.Debug.WriteLine("Loop");
                System.Diagnostics.Debug.WriteLine(single.Album.AccountInfo.DisplayName);
            }
        }
    }
