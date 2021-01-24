    [HttpPost]
    public ActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(movie);
    }
