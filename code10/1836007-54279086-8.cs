    public IEnumerable<Movie> GetTopFive()
    {
        var result = _moviesDbContext.Movies.GroupBy(x => new { x.Id, x.Title })
            .Select(x => new {
                Id = x.Key.Id,
                Title = x.Key.Title,
                Average = x.Average(y => y.Ratings.Sum(z => z.RatingValue))
        }).OrderByDescending(x => x.Average).ThenBy(x => x.Title).Take(5).ToList();
        return result;
    }
