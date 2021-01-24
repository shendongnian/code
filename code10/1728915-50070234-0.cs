    public ActionResult DisplaySearchResults(int[] selectedGenres)
    {
        var filteredMovies = db.Movies.Include("Genres")
            .Where(movie => selectedGenres == null ||
                            !selectedGenres.Any() ||
                            movie.Genres.Any(genre => selectedGenres.Contains(genre.GenreID)))
            .ToList();
        return View("Index", filteredMovies);
    }
