    public static void SignIn(UserManager manager, ApplicationUser user, bool isPersistent)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
    
        //CUSTOM CODE Start
        //get image url claim from Google Identity
       if (authenticationManager.GetExternalLoginInfo().Login.LoginProvider == "Google")
         {
            var externalIdentity = authenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
            var picClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type.Equals("picUrl"));
            var picUrl = picClaim.Value;
            //add a claim for profile pic url to ASP.Net Identity
            identity.AddClaim(new System.Security.Claims.Claim("picUrl", picUrl));
         }
        //CUSTOM CODE end
        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent , ExpiresUtc = DateTime.UtcNow.AddMinutes(5), RedirectUri="http://www,appsprocure.com"  }, identity);
    }
