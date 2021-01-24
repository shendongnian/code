    public ActionResult GetUserInfo()
    {
        string ip = HttpContext.Request.UserHostAddress;
        string name = HttpContext.Request.RequestContext.HttpContext.User.Identity.Name;
        return Json(new { name = name, ip = ip }, JsonRequestBehavior.AllowGet);
    }
