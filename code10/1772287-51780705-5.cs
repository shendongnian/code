    [HttpGet]
    public ActionResult ActionName(string id)
    {
        // do something
        return Json(new { status = "success", buttonID = id }, JsonRequestBehavior.AllowGet);
    }
    [HttpGet]
    public ActionResult AnotherAction()
    {
        // do something
        return View(model);
    }
