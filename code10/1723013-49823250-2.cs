    [HttpGet]
    public ActionResult EditDetailsForm(string username)
    {
        var user = GetUser(username);
        return PartialView("_editForm", user);
    }
