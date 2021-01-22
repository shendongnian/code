    using Microsoft.Win32;
    //during init of your application bind to this event   
    SystemEvents.SessionEnding += 
        new SessionEndingEventHandler(SystemEvents_SessionEnding);
    
    void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e) 
    {     
        if (e.Reason == SessionEndReasons.Logoff) 
        {  
            // insert your code here
        }
    }
