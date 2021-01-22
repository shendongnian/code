            public ActionResult Login(string userName, string password, bool persistent, string returnUrl)
        {
            
            if (returnUrl != null && returnUrl.IndexOf("/user/login", StringComparison.OrdinalIgnoreCase) >= 0)
                returnUrl = null;
            if (Membership.ValidateUser(userName, password))
            {
                FormsAuthentication.SetAuthCookie(userName, persistent);
                if (!String.IsNullOrEmpty(returnUrl))
                    return this.Redirect(303, returnUrl);
                else
                    return this.Redirect(303, FormsAuthentication.DefaultUrl);
            }
            else
                TempData["ErrorMessage"] = "Login failed! Please make sure you are using the correct user name and password.";
            return View();
        }
