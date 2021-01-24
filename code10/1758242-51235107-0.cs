    public ActionResult Random()
    {
    
        var movie = new Movie() { Name = "Star Trek!" };
        return View(movie);
    }
