            using (MovieContext dbContext = new MovieContext())
            {
                var newMovieDetails = dbContext.Movies.FirstOrDefault(x => x.MovieID == id);
                var MappedDetails = new MovieDetails
                {
                    MovieID = newMovieDetails.MovieID,
                    MovieName = newMovieDetails.MovieName
                };
                return MappedDetails;
            }
        }
