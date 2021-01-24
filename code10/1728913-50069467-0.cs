    foreach (int GenreID in SelectedGenres)
    {
        //need to query where there's at least one genre, not all
        //EX.Western and Horror selected should return movies that have either western or horror as a genre, not both.
        query = query.Where(r => r.Genres.Any(x => x.GenreID == GenreID));
    }
