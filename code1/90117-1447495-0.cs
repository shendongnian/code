    ManagementScope scope = new ManagementScope(@"\root\nap");
    scope.Connect();
    
    ObjectQuery query = new ObjectQuery("SELECT * FROM NAP_Client");
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    {
        int isolationState = 0;
        foreach (ManagementObject m in searcher.Get())
        {
            isolationState = int.Parse(m["systemIsolationState"].ToString());
        }
    
        if (isolationState == 3) // 3 means in quarantine
        {
            //NAP is preventing the computer access to the network
            ....do something
        }
    }
