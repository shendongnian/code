    public static Genre BrowseGenre(string genre)
            {
                using (MusicStoreEntities db = new MusicStoreEntities())
                {
                    //return db.Database.SqlQuery<Genre>("GetAllGenres").Include("Albums").Single(g => g.Name == genre);
                    return db.Genres.Include("Albums").Single(g => g.Name == genre);
                }                
            }
