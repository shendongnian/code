    using System.Management;
    String queryString = "select CreationDate from Win32_Process where ProcessId='" + ProcessId + "'";
    SelectQuery query = new SelectQuery(queryString);
    
    ManagementScope scope = new System.Management.ManagementScope(@"\\.\root\CIMV2");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection processes = searcher.Get();
    
        //... snip ... logic to figure out which of the processes in the collection is the right one goes here
    
    DateTime startTime = ManagementDateTimeConverter.ToDateTime(processes[0]["CreationDate"].ToString());
    TimeSpan uptime = DateTime.Now.Subtract(startTime);
