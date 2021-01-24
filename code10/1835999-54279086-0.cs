    public IEnumerable<Movie> GetTopFive()
    {
        var result = _moviesDbContext.Movies.Include(m => m.Ratings).OrderByDescending(m => m.Ratings.Select(r => r.RatingValue)).Take(5).ToList();
        return result;
    }
