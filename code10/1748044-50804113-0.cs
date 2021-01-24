    public ActionResult Login()
    {
        var detail = new Details()
        {
            GroupId = 23,
            GroupPassword = "280phcdd12",
        };
        ViewBag.GroupId = detail.GroupId;
        ViewBag.GroupPassword = detail.GroupPassword;
        return View();
    }
