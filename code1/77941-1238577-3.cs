    if (Request.QueryString["use"] == "windows")
    {
        var windowsuser = Request.ServerVariables["LOGON_USER"];
        if (windowsuser.Length == 0)
            ActivateWindowsLogin();
        else
        {
            // get userId from DB for Windows user that was authenticated by IIS
            // I use userId in .ASPXAUTH cookie
            var userId = GetUserIdForWindowsUser(windowsuser);
            if (userId > 0) //user found
            {
                // here we get User object to check roles or other stuff
                var user = GetApplicationUser(userId);
                // perform additional checks here and call ActivateWindowsLogin()
                // to show login again or redirect to access denied page.
                // If everythig is OK, set cookie and redirect
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(userId.ToString(), false), true);
            }
            else //user not found
                ActivateWindowsLogin();
        }
    }
    else
    {
        //your Forms auth routine
    }
