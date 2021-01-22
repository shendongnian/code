    void Application_BeginRequest(object sender, EventArgs e)
    {
        // Handles all incoming requests
        string strURLrequested = Context.Request.Url.ToString();
        GetURLToRedirect objUrlToRedirect = new GetURLToRedirect(strURLrequested); 
        Context.RewritePath(objUrlToRedirect.RedirectURL);
    }
