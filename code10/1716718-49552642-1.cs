    if (User.IsInRole("admin")) //whatever your admin role is called
    {
        return View();
    }
    if (User.IsInRole("user"))
    {
        return View("IndexUser");
    }
    return View("Whatever"); //or RedirectToAction(...)
