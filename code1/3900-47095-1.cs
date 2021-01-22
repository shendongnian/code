    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
       if (HttpContext.Current.Request.IsSecureConnection.Equals(false))
       {
        Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
    +   HttpContext.Current.Request.RawUrl);
       }
    }
