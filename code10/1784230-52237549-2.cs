    public ActionResult Index()
    {
        //some server side processing....
        ViewBag.Foo = DateTime.Now.Second % 2 == 0;
        return View();
    }
