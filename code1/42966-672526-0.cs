    [WebMethod]
    public bool IsAlive()
    {
         string callingAddress = HttpContext.Current.Request.UserHostAddress;
         return (callingAddress == allowedAddress);
    }
