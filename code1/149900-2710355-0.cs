    protected void Application_EndRequest()
    {
        if ((Response.ContentType == "text/html") && (Request.IsAuthenticated))
        {
            var webUser = Context.User as WebUser;
            if (webUser != null)
            {
                //Update their last activity
                webUser.LastActivity = DateTime.UtcNow;
                //Update their page hit counter
                webUser.ActivityCounter += 1;
                //Save them
                var webUserRepo = Kernel.Get<IWebUserRepository>(); //Ninject
                webUserRepo.Update(webUser);
            }
        }
    }
