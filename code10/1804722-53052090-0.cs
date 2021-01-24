    var moviesAndAverageGradeSortedList = _deserializator.RatingCollection()
                .GroupBy(movieId => movieId.Movie)
                .Select(group => new
                {
                    Key = group.Key, 
                    Average = group.Average(g => g.Grade)
                })
                .OrderByDescending(a => a.Average)
                .Take(amountOfMovies)
                .Select(s=> s.Key)
                .ToList();
