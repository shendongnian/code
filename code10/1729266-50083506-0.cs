    [HttpPost]
    public ActionResult Create(MovieGenresDirectorsRatings[] mgdr) // The ViewModel
    {
        foreach(var genr in mgdr){
              try
              {
                  genr.CMovie.Insert(); //inserting each object received from view. 
                  return RedirectToAction("Index");
              }
              catch (Exception ex)
              {
                  throw ex;
                  return View(mgdr);
              }
        }
    }
