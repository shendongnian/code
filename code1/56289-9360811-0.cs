    protected void Application_Start()
    {
        PostAuthenticateRequest += Application_PostAuthenticateRequest;
    }
    
    protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        if(User.Identity.IsAuthenticated)
        {
            //Do stuff here
        }
    }
