    protected FormsAuthenticationTicket GetAuthTicket()
    {
        HttpCookie authCookie = Request.Cookies["CookieFA"];
        if (authCookie == null) return null;
        try
        {
            return FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch(System.CryptographicException exception)
        {
            _log.Debug("Can't decrypt cookie! {0}", exception.Message);
            return null;
        }
    }
    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        var authTicket = GetAuthTicket();
        if (authTicket != null)
        {
            CustomPrincipal principal = new CustomPrincipal(authTicket.Name);
            CustomPrincipalSerializeModel userSerializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
            principal.UserID = userSerializeModel.ID;
            principal.FirstName = userSerializeModel.FirstName;
            principal.LastName = userSerializeModel.LastName;
            principal.Roles = userSerializeModel.RoleName.ToArray<string>();
            HttpContext.Current.User = principal;
        }
    }
