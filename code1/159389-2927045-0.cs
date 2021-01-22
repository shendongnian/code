    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index(string title, string tags, int? page)
    {
        var list = GetSomeData(title, tags, page);
        return View(list);
    }
