    MovieDetails newMovieDetails = dbContext.Movies.FirstOrDefault(x => x.ID == id)?.Select(x => new MovieDetails
        {
            MovieID = x.ID,
            MovieName = x.MovieName,
            BroughtBy = (int)x.BroughtBy,
            Director = x.Director,
            Rating = (int)x.Rating
        });
