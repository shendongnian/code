    public ActionResult Index(string catName)
    {
        if (string.IsNullOrEmpty(catName) || !MyCategoriesDataStore.Exists(catName))
            return RedirectToAction("CategoryError");
        // Load category data to be used from View
        return View();
    }
