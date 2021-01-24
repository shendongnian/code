    void Application_End(object sender, EventArgs e) 
        {
            //  Code that runs on application shutdown
            Session.RemoveAll();
            Session.Clear();
            
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
