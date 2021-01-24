    [HttpPost]
    public ActionResult DeleteConfirmed(int id)
    {
        User user = db.Users.Find(id);
        db.Users.Remove(user);
        db.SaveChanges();
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Index", "Home");
    }
