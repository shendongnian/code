    public ActionResult Login()
    {
       if (User.Identity.IsAuthenticated)
          return RedirectToAction("Index", "Home");
    
       return View();
    } 
