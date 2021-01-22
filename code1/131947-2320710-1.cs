    using(DataContext db = new DataContext())
    {
            var query = from p2 in db.SONG
                        where p2.UserID == givenUserID
                        join p in db.ARTIST
                        on p2.ArtistID equals p.ArtistID
                        select new ArtistSongStruct
                        {
                            ArtistName = p.Name,
                            songName = p2.songName
                        };   
            return query.ToList();
    }
