    public ActionResult Index()
    {
         ViewData("EffectiveDate") = DateTime.Now;
         return View();
    }
