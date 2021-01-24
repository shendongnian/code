    //LogOut
    [HttpPost]
    public ActionResult LogOut()
    {
        FormsAuthentication.SignOut();
        TempData.Clear();
        Session.Abandon();
        getDB.Close();
        return RedirectToAction("Home");
    }
