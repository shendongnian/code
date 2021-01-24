    [AllowAnonymous]
    public ActionResult Activation()
    {
        if (!this.Request.IsAuthenticated)
        {
            // sign in using WsFederation, works
        }
        else if (User.Identity.AuthenticationType == "{YOUR_AUTHENTICATION_TYPE}")
        {
            return Redirect("/");
        }
        return View();
    } 
