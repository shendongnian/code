    [WebMethod(EnableSession = true)]
    public string checkSession()
    {
        return HttpContext.Current.Session.SessionID
    }
