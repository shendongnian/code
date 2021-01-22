    protected void Application_Error(Object sender, EventArgs e)
    {
      Exception ex = Server.GetLastError().GetBaseException();
      string file = HttpContext.Current.Request.Url.ToString();
      string page = HttpContext.Current.Request.UrlReferrer.ToString(); 
    }
