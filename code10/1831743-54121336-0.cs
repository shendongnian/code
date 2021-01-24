    public ActionResult CreateDeliverable(int? idResearch, int? idBaseline, int? idYear){
    ViewBag.IdResearch = idResearch;
    ViewBag.IdBaseline = idBaseline;
    ViewBag.IdYear = idYear;
    ViewBag.Year = db.Deliverable_Research_Years.Find(idYear);
    return View(db.Deliverables.ToList());
    }
