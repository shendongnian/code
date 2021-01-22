    TestContext db = new TestContext(CreateSparqlTripleStore());
    var q = from a in db.Album
            join t in db.Track on a.Name equals t.AlbumName into tracks
            select new Album{Name = a.Name, Tracks = tracks};
    foreach(var album in q){
        Console.WriteLine(album.Name);
        foreach (Track track in album.Tracks)
        {
            Console.WriteLine(track.Title);
        }
    }
