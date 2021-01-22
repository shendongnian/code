     protected void status()
        {
            string appPoolName = "dev.somesite.com";
            string appPoolPath = @"IIS://" + System.Environment.MachineName + "/W3SVC/AppPools/" + appPoolName;
            int intStatus = 0;
            try
            {
                DirectoryEntry w3svc = new DirectoryEntry(appPoolPath);
                intStatus = (int)w3svc.InvokeGet("AppPoolState");
                switch (intStatus)
                {
                    case 2:
                        lblStatus.Text = "Running";
                        break;
                    case 4:
                        lblStatus.Text = "Stopped";
                        break;
                    default:
                        lblStatus.Text = "Unknown";
                        break;
                }
            }
