    public ActionResult Index()
    {
        var strategy = new Strategy();  // a concrete model type/class
        // do some stuffs...
        // using ViewBag to pass a bag of stuffs...
        return View(strategy);
    }
