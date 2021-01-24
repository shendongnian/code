    HttpCookie cookie = Request.Cookies[__RequestVerificationToken];
    // check for null
    if (cookie == null)
    {
        // no cookie found, create it... or respond with an error
    }
    else
    {
        // grab the cookie
        AntiForgery.GetTokens(Request.Form[__RequestVerificationToken], out cookieToken, out formToken);
        
        if (!String.IsNullOrEmpty(cookieToken)
        {
            // update the cookie value(s)
            cookie.Values[__RequestVerificationToken] = cookieToken;
            //...
        }
    }
    
    // update the expiration timestamp
    cookie.Expires = DateTime.UtcNow.AddDays(30);
    // overwrite the cookie
    Response.Cookies.Add(cookie);
