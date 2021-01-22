        Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            { 
                //I left my desk
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            { 
                //I returned to my desk
            }
        }
