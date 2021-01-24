    services.Configure<CookiePolicyOptions>(options =>
      {
          // This lambda determines whether user consent for non-essential cookies is needed for a given request.
          options.CheckConsentNeeded = context => true;
          options.MinimumSameSitePolicy = SameSiteMode.None;
      });
If thats the case, you can set the cookie with the CookieOption.IsEssential = true like so:
    var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
        {
          Path = "/", HttpOnly = false, IsEssential = true, //<- there
          Expires = DateTime.Now.AddMonths(1), 
        };
