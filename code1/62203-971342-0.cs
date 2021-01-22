    ConnectionOptions options;
    options = new ConnectionOptions();
    
    options.Username = userID;
    options.Password = password;
    options.EnablePrivileges = true;
    options.Impersonation = ImpersonationLevel.Impersonate;
    
    ManagementScope scope;
    scope = new ManagementScope("\\\\" + ipAddress + "\\root\\cimv2", options);
    scope.Connect();
    
    String queryString = "SELECT PercentProcessorTime, PercentInterruptTime, InterruptsPersec FROM Win32_PerfFormattedData_PerfOS_Processor";
    
    ObjectQuery query;
    query = new ObjectQuery(queryString);
    
    ManagementObjectSearcher objOS = new ManagementObjectSearcher(scope, query);
    
    DataTable dt = new DataTable();
    dt.Columns.Add("PercentProcessorTime");
    dt.Columns.Add("PercentInterruptTime");
    dt.Columns.Add("InterruptsPersec");
    
    foreach (ManagementObject MO in objOS.Get())
    {
        DataRow dr = dt.NewRow();
        dr["PercentProcessorTime"] = MO["PercentProcessorTime"];
        dr["PercentInterruptTime"] = MO["PercentInterruptTime"];
        dr["InterruptsPersec"] = MO["InterruptsPersec"];
    
        dt.Rows.Add(dr);
    }
