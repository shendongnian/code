    Public ActionResult Logout()
    {
        Session["LoggedData"] = null;
        Session.Abandon();
        return RedirectToAction("Default", "Home");
    }
