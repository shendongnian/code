    [HttpPost] // <-- note that this one is HttpPost
    public ActionResult Vehicles(Filter userFilter)
    {
        // refine the search and send the user back to Vehicles view
        var e = db.Vehicles.Where(x => x.availability == true && 
                                  x.Price <= userFilter.MaxPrice &&
                                  string.Equal(x.Model, userFilter.Make).ToList();
        return View(e);
    }
