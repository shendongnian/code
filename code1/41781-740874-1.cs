    try
    {
    	user.Login();
    	AuthenticationManager.SignIn(user);
    }
    catch (RulesException rex)
    {
    	// on bad login
    	rex.AddModelStateErrors(ModelState, "user");
    	TempData["ModelState"] = ModelState;
    	return Redirect(Request.UrlReferrer.ToString());
    }
