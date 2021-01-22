    public ActionResult Success(string id) 
    {
        // Maybe perform some logic based on the id parameter
        TempData["paymentType"] = id;
        return RedirectToAction("Index");
    }
    public ActionResult Index()
    {
        ViewData["paymentType"] = TempData["paymentType"];
        return View();
    }
