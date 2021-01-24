    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
        if (Session["RoleID"] != null)
        {
            if (Convert.ToInt32(Session["RoleID"]) == Ansits2018.UTILITIES.Constants.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    
        if (ModelState.IsValid)
        {
            var accRepo = new AccountRepository();
            int UserID = 0;
            UserID = accRepo.IsUserValid(model.UserName, model.Password);
    
            if (UserID > 0)
            {
                var user = accRepo.GetUserByUsername(model.UserName);
                Session["CompanyID"] = 1;
                Session["UserID"] = UserID;
                Session["Username"] = model.UserName;
                Session["RoleID"] = user.RoleID;
                Session["Name"] = user.Name;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                                    1,                                   // ticket version
                                                    user.Username,  // authenticated username
                                                    DateTime.Now,                        // issueDate
                                                    DateTime.Now.AddMinutes(60),        // expiryDate
                                                    true,                                // true to persist across browser sessions
                                                    user.RoleID.ToString(),       // can be used to store additional user data
                                                    FormsAuthentication.FormsCookiePath  // the path for the cookie
                                                    );
    
                // Encrypt the ticket using the machine key
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                // Add the cookie to the request to save it
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    System.Diagnostics.Debug.WriteLine("1 #####> RedirectToLocal (valid Login): " + returnUrl);
                    return RedirectToLocal(returnUrl);
                }
                if (user.RoleID == Ansits2018.UTILITIES.Constants.Admin)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("2 #####> Invalid Login Attempt - UserID > 0: " + model.UserName + " => " + model.Password));
                TempData["Message"] = "Invalid username or password.";
                return View(model);
            }
        }
    
        System.Diagnostics.Debug.WriteLine("3 #####> ModelState Invalid: " + model.UserName + " => " + model.Password);
        return View(model);
    }
