    [HttpPost]
    public ActionResult Index(IEnumerable<string> selectedValues)
    {
        return View(selectedValues);
    }
