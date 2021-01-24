    //Get list of matches from DB into a list in one hit.
    var possibleMovies = _context.Movies.Where(m=>newRental.MovieIds.Contains(m.Id)).ToList();
    //Match up entries in request to DB entries.
    movies = newRental.MovieIds
        .Select(rm => possibleMovies.FirstOrDefault(m => m.Id==rm))
        .Where(x => x != null) //Just make sure no entries are NULL.. optional
        .ToList();
