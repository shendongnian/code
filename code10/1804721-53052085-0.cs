    return _deserializator.RatingCollection()
                .GroupBy(i => i.Movie)
                .OrderByDescending(g => g.Average(i => i.Grade))
                .Select(g => g.Key)
                .Take(amountOfMovies)
                .ToList();
