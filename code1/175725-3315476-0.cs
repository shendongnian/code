    //Connection credentials to the remote computer – not needed if the logged in account has access 
    ConnectionOptions oConn = new ConnectionOptions(); 
    oConn.Username = "JohnDoe"; 
    oConn.Password = "JohnsPass"; 
    
    System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\MachineX", oConn);     
    
    //get Process objects 
    System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("Select * from Win32_Process"); 
    foreach( ManagementObject oReturn in oReturnCollection ) 
    { 
        //Name of process 
        Console.WriteLine(oReturn["Name"].ToString().ToLower()); 
        //arg to send with method invoke to return user and domain – below is link to SDK doc on it 
        string[] o = new String[2];                 
        //Invoke the method and populate the o var with the user name and domain 
        oReturn.InvokeMethod("GetOwner",(object[])o); 
        //write out user info that was returned 
        Console.WriteLine("User: " + o[1]+ "\" + o[0]); 
        Console.WriteLine("PID: " + oReturn["ProcessId"].ToString()); 
        //get priority 
        if(oReturn["Priority"] != null) 
            Console.WriteLine("Priority: " + oReturn["Priority"].ToString()); 
         
        //get creation date – need managed code function to convert date – 
        if(oReturn["CreationDate"] != null) 
        { 
            //get datetime string and convert 
            string s = oReturn["CreationDate"].ToString(); 
                //see ToDateTime function in sample code 
            DateTime dc = ToDateTime(s);                         
            //write out creation date 
            Console.WriteLine("CreationDate: " + dc.AddTicks(-TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks).ToLocalTime().ToString()); 
        } 
         
        //this is the amount of memory used 
        if(oReturn["WorkingSetSize"] != null) 
        { 
             ass="keyword">long mem = Convert.ToInt64(oReturn["WorkingSetSize"].ToString()) / 1024; 
            Console.WriteLine("Mem Usage: {0:#,###.##}Kb",mem); 
        } 
    }
