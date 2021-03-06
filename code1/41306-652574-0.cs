     // ...
     SystemEvents.SessionSwitch += 
        new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
     // ...
     void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
     {
         switch(e.Reason)
         {
             case SessionSwitchReason.SessionLock:
             // ...
             break;
             case SessionSwitchReason.SessionUnlock:
             // ...
             break;
             // ...
         }
     }
