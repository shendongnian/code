    [WebMethod(true)]
    public string MyMethod()
    {
        if(!userIsLoggedIn)
        {
           HttpContext.Current.Response.StatusCode = 403;
           return null;
        }
    }
