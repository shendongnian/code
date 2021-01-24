    //Original
    private IEnumerable<Movie> GetMovies()
    {
        return new List<Movie>
        {
            new Movie {Id = 1, Name = "Shrek"},
            new Movie {Id = 2, Name = "LotR"}
        };
    }
    //Using an array
    private IEnumerable<Movie> GetMovies()
    {
        return new Movie[]
        {
            new Movie {Id = 1, Name = "Shrek"},
            new Movie {Id = 2, Name = "LotR"}
        };
    }
    //From EF
    private IEnumerable<Movie> GetMovies()
    {
        return dbContext.Movies.Where( m => Name == "Shrek" || Name == "Lotr );
    }
    //Covariant
    class NerdMovie : Movie {}
    private IEnumerable<Movie> GetMovies()
    {
        return new List<NerdMovie>
        {
            new NerdMovie {Id = 1, Name = "Shrek"},
            new NerdMovie {Id = 2, Name = "LotR"}
        };
    }
    //Custom type
    class MovieList : List<Movie> { }
    private IEnumerable<Movie> GetMovies()
    {
        return new MovieList
        {
            new Movie {Id = 1, Name = "Shrek"},
            new Movie {Id = 2, Name = "LotR"}
        };
    }
