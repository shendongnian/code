    var data = _moviesDbContext.Movies
                .Select(x => new {
                    Id = x.Id,
                    Title = x.Title,
                    Average = x.Ratings.Average(y => y.RatingValue)
            }).OrderByDescending(x => x.Average).ThenBy(x => x.Title).Take(5).ToList();
