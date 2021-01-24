    model.Songs = model.Albums
        .SelectMany       //Combine all albums songs into one list
        (
            a => a.Songs 
        )
        .Where           //Only take those that are in the playlist
        (
            s => model.PlaylistSongs.Any
            ( 
                p => p.SongID == s.SongID 
            )
        )
        .ToList();
              
    foreach (var single in model.Songs)
    {
        Debug.WriteLine("Loop");
        Debug.WriteLine(single.Album.AccountInfo.DisplayName);
    }
