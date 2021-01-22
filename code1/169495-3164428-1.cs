    Process[] myApp = Process.GetProcesses("My Application");
            if (myApp.Length == 0)
            {
                // App closed, and check the user status
                // If user is still up, make it logoff,
                // Also you can track processes with ProcessId too GetProcessesById(5415)
            }
            else
            {
                // App is running, there is no problem
            }
