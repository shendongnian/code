    foreach (var song in songs)
    {
        if (string.IsNullOrWhiteSpace(name) || song.GetArtist().Equals(name))
        {
              Console.WriteLine(song.GetDetails());
              song.GetCertification() != null ? song.GetCertification() : /* Handle no certificate here */;
        }
    }
