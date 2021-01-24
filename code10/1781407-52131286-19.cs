    [HttpPost]
    public ActionResult Create(MoviesActorsViewModel mcvm)
    {
        _context.mvz.Add(mcvm.mvz);
        _context.actrs.Add(mcvm.act);
        return RedirectToAction("GetView", "Default");
    }
