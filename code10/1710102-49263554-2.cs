    public ActionResult Update()
    {
        var users = context.Users.ToList();
        foreach(var user in users)
        {
           user.Activated = "Yes";
        }
        return View("Index", users);
    }
