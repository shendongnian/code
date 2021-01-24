    public async Task AddMoviesToStudioAsync(List<Movie> movies, int studioId) 
    {
        var movieStudiosList
            = movies.Select(
                movie => new MovieStudios
                {
                    MovieId = movie.Id, 
                    StudioId = studioId
                })
                .ToList();
        await DbContext.Set<MovieStudios>().AddRangeAsync(movieStudiosList);
    }
