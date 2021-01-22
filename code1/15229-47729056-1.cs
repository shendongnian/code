    [HttpPost]
    public ActionResult Login(FormCollection collection)
    {
      LogedinUserDetails User_Details = LogedinUserDetails.Singleton();
      User_Details.UserID = "12";
      User_Details.UserRole = "SuperAdmin";
      User_Details.UserSupervisor = "815978";
      return RedirectToAction("Dashboard", "Home");
    }
