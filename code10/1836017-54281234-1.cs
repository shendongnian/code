    public IEnumerable<MovieRating> GetTopFive()
        {
            var result = _moviesDbContext.Movies.Include(x => x.Ratings)
                .Select(x => new MovieRating
                {
                    Id = x.Id,
                    Title = x.Title,
                    Average = x.Ratings.Average(y => y.RatingValue)
                }).OrderByDescending(x => x.Average).ThenBy(x => x.Title).Take(5).ToList();
            return result;
        }
    public class MovieRating
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Average { get; set; }
    }
