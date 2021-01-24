    public class Movie
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public virtual MovieGenre MovieGenre { get; set; }
    
            public byte MovieGenreId { get; set; }
    }
    public class MovieGenre
        {
            public byte Id { get; set; }
    
            public string Name { get; set; }
        }
