    var totalSold = 0;
    foreach (var song in songs)
    {
        if (string.IsNullOrWhiteSpace(name) || song.GetArtist().Equals(name))
        {
            //rest of your code       
     
            totalSold += song.copiesSold; //same as totalSold = totalSold + song.CopiesSold
        }
    }
