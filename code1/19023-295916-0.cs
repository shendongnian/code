    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(object));
        using (log4net.NDC.Push(this.User.Identity.Name))
        {
            log.Fatal("Unhandled Exception", Server.GetLastError());
        }
    }
