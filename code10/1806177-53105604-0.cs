    public ActionResult Roles(string applicationId)
    {
        if (string.IsNullOrEmpty(applicationId))
        {
            return View();
        }
        var application = new ApplicationStore().ReadForId(applicationId);
        return View(application);
    }
