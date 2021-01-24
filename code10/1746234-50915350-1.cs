    public ActionResult Logout() {
        FormsAuthentication.SignOut();
        Session.AbandonAndClearSessionCookie();
        return RedirectToAction("Index", "Home");
    }
