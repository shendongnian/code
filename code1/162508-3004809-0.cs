    [HttpPost]
    public ActionResult Index(string contentList)
    {
        // contentList will contain the selected value
        return RedirectToAction("Details", contentList);
    }
