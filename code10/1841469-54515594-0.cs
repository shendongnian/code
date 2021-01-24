    foreach (var song in songs)
    {
       if (string.IsNullOrWhiteSpace(artist) || song.GetArtist().Equals(artist))
       {
    	Console.WriteLine(song.GetDetails());
       }
    }
