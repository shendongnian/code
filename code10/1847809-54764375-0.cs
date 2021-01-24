    HttpCookie authCookie = Request.Cookies["CookieFA"];
    if (authCookie == null) return;
    FormsAuthenticationTicket authTicket = null;
    try
    {
        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    }
    catch(System.CryptographicException exception)
    {
        _log.Debug("Can't decrypt cookie! {0}", exception.Message);
        return;
    }
    CustomPrincipal principal = new CustomPrincipal(authTicket.Name);
    //etc.
    HttpContext.Current.User = principal;
