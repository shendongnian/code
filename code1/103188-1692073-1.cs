    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult LogOn(string username, string password)
    {
        if (FormsAuthentication.Authenticate(username, password))
        {
            FormsAuthentication.SetAuthCookie(username, false);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewData["LastLoginFailed"] = true;
            return View();
        }
    }
