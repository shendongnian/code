    public ActionResult Login()
    {
       if (User.IsInRole("ProvideASpecificRoleHere"))
          return RedirectToAction("Index", "Home");
    
       return View();
    }
