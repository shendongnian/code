    public ActionResult GetView()
    {
        MoviesActorsViewModel mcvm = new MoviesActorsViewModel();
        mcvm.act = _context.actrs.ToList();
        return View(mcvm);
    }
