    public ActionResult LogOffAction()
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Index", "Home");
    }
