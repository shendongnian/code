     using Microsoft.Win32;
     // ...
     // Somewhere in your startup, add your event handler:
        SystemEvents.SessionSwitch += 
           new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
     // ...
     void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
     {
         switch(e.Reason)
         {
             // ...
             case SessionSwitchReason.SessionLock:
                // Do whatever you need to do for a lock
                // ...
             break;
             case SessionSwitchReason.SessionUnlock:
                // Do whatever you need to do for an unlock
                // ...
             break;
             // ...
         }
     }
