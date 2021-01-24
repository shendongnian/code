    public IEnumerable<Movie> GetTopFive()
    {
        var result = _moviesDbContext.Ratings.GroupBy(r => r.MovieId).Select(group => new
            {
                MovieId = group.Key,
                MovieTitle = group.Select(g => g.Movie.Title).FirstOrDefault(),
                AvgRating = group.Average(g => g.RatingValue)
            }).OrderByDescending(s => s.AvgRating).Take(5).ToList();
        return result;
    }
