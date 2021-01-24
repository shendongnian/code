    return this.SignOut(
             new  Microsoft.AspNetCore.Authentication.AuthenticationProperties 
             {
                  RedirectUri = this.GetReturnUrl() 
             },
             CookieAuthenticationDefaults.AuthenticationScheme,
             WsFederationDefaults.AuthenticationScheme);
