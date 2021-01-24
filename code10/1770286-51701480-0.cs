    var artist = db.Include(x => x.SpotifyAccounts)
                   .Include(x => x.YouTubeVideos)
                   .Include(x => x.EbayStores)
                   .FirstOrDefault(x => x.Name == SearchName); 
    
    Console.WriteLine(artist.Name);
    if(artist.SpotifyAccounts.Any)
       foreach(var item in artist.SpotifyAccounts)
           Console.WriteLine(" -- " + item.Url);
    
    var spotify = db.SpotifyAccounts
                    .Include(x => x.Arists)
                    .FirstOrDefault(x => x.Id == SpotifyId);
    
    Console.WriteLine(spotify.Id);
    Console.WriteLine(spotify.Url);
    Console.WriteLine(spotify.Artist.Name);
                  
