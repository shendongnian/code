    var movieQuery = from u in _context.Movie
                     join g in _context.Ratings on u.Rating equals g.ID
                     select new
                     {
                         Ratings = u.Rating,
                         MovieRating = g.MovieRating
                     };
    var movies = await movieQuery.ToListAsync(); // query will be executed here
