    public ActionResult Index()
    {
        var model = db.ViewModel
            .Include(c => c.Categories);
            .Include(c => c.Ads);
        return View(model.ToList());
    }
