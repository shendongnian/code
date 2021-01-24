    // assuming higher ratings are better:
    static void Main(string[] args)
    {
        List<Movie> movieColletion = GetMovieCollection();
        List<Movie> top20Movies = movieCollection
            .OrderByDescending(m => m.rating)
            .Take(20)
            .ToList();
    }
