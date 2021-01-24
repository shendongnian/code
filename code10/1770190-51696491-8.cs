    public ActionResult Index(string spHostUrl)
    {
       ViewBag.SpHostUrl = spHostUrl;
       return View();
    }
