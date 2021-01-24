    public ActionResult Index()
    {
        ViewBag.CA = Session["cAnswers"];
        return View();
    }
