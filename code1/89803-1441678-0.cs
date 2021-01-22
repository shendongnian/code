    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Index(TestModel model)
    {
      ViewData["Message"] = model.Test1;
      return View();
    }
