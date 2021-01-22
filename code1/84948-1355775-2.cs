    public ActionResult Index()
    {
      return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(FormCollection collection)
    {
      ViewDate.Add("response", collection["myInput"]);
      return View();
    }
