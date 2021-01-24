    public ActionResult Index()
    {
        return View();
    }
    public ActionResult HandleJsonArray()
    {
        //get roles
        return Json(roles, JsonRequestBehavior.AllowGet);
    }
