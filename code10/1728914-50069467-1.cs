    foreach (int GenreID in SelectedGenres)
    {
        //saving the results of each query.Where call to the SelectedMovies List
        SelectedMovies.AddRange(query.Where(r => r.Genres.Any(x => x.GenreID == GenreID)).ToList());
    }
