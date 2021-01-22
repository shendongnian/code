    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["Sessions"] = 0;
    }
    void Session_Start(object sender, EventArgs e) 
    {
       // Code that runs when a new session is started
       Application.Lock();
       Application["Sessions"] = (int)Application["Sessions"] + 1;
    
       if ((int)Application["Sessions"] % 5 == 0)
       {
         DoSomething();
         Application["Sessions"] = 0;
        }
        Application.UnLock();
    }
