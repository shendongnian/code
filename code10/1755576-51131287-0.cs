    var query = Context.Analytics
    .Where(x => x.AlbumID == albumId)
    .GroupBy(c => c.AlbumID)
    .Select(
        g =>
            new
            {
                Id = g.Key,
                Spotify = g.Sum(s => s.SpotifyClicks),
                ITunes = g.Sum(s => s.ItunesClicks),
            }
    );
