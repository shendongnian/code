    public ActionResult Index()
    {
        dictionaryviewmodel dictViewModel = new dictionaryviewmodel();
        dictViewModel.dictInViewModel.dpdnDict.Add("M", "Male");
        dictViewModel.dictInViewModel.dpdnDict.Add("F", "Female");
        return View(dictViewModel);
    }
