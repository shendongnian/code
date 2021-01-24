    // Force delete the authentication cookie(s) we created when user signed in
    if (HttpContext.Request.Cookies[".AspNetCore.MyCookie"] != null)
       {
        var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.StartsWith("AspNetCore.MyCookie"));
        foreach (var cookie in siteCookies)
           {
            Response.Cookies.Delete(cookie.Key);
           }
        }
