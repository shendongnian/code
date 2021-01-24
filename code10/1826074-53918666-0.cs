    [HttpPost]
    public ActionResult Create(Movie movie)
    {
        //setdate
        movie.DateAdded = Datetime.Now;
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return RedirectToAction("Index", "Movies");
    }
