    public ActionResult Dashboard()
        {
            LogedinUserDetails User_Details = LogedinUserDetails.Singleton();
            ViewData["UserID"] = User_Details.UserID;
            ViewData["UserRole"] = User_Details.UserRole;
            ViewData["UserSupervisor"] = User_Details.UserSupervisor;
            
            return View();
        }
