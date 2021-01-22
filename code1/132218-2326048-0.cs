    public ActionResult Index() 
    {
        return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(SomeModel model) 
    {
       return View();
    }
