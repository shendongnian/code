    [Url("")]
    public ActionResult Index() { return View(); }
    [Url("foo")]
    [HttpPost]
    public ActionResult Index(string id) { return View(); }
