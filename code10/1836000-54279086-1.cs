    public IEnumerable<Movie> GetTopFive()
    {
        var result = _moviesDbContext.Ratings.GroupBy(d => d.MovieId).Select(group => new
            {
                MovieId = group.Key,
                MovieTitle = group.Select(g => g.Movie.Title),
                AvgRating = group.Select(g => g.RatingValue).Sum() / group.Count()
            }).OrderByDescending(s => s.AvgRating).Take(5).ToList();
        return result;
    }
