            //The following security adjustments are necessary to give the new 
            //process sufficient permission to run in the service's window station
            //and desktop. This uses classes from the AsproLock library also from 
            //Asprosys.
            IntPtr hWinSta = GetProcessWindowStation();
            WindowStationSecurity ws = new WindowStationSecurity(hWinSta,
              System.Security.AccessControl.AccessControlSections.Access);
            ws.AddAccessRule(new WindowStationAccessRule("LaunchProcessUser",
                WindowStationRights.AllAccess, System.Security.AccessControl.AccessControlType.Allow));
            ws.AcceptChanges();
            IntPtr hDesk = GetThreadDesktop(GetCurrentThreadId());
            DesktopSecurity ds = new DesktopSecurity(hDesk,
                System.Security.AccessControl.AccessControlSections.Access);
            ds.AddAccessRule(new DesktopAccessRule("LaunchProcessUser",
                DesktopRights.AllAccess, System.Security.AccessControl.AccessControlType.Allow));
            ds.AcceptChanges();
            EventLog.WriteEntry("Launching application.", EventLogEntryType.Information);
            using (Process process = Process.Start(psi))
            {
            }
