    public ActionResult EditUser(User user)
    {
        return View(user);
    }
    public ActionResult SaveUser(User user)
    {
        // Do something with user to save it
        // then show the Edit form again
        return View("EditUser", user);
    }
