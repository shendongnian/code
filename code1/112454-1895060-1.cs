    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(string title, string summary)
    {
        Tour tour = this.TourManager.CreateTour(string.IsNullOrEmpty(title) ? DefaultText.TourTitle : title, string.IsNullOrEmpty(summary)? DefaultText.TourSummary : summary);
        return RedirectToAction("Edit", new { id = tour.id } );
    }
