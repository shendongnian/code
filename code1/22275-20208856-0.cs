    ConnectionOptions connectoptions = new ConnectionOptions();
    connectoptions.Username = string.Format(@"carpark\{0}", "domainOrWorkspace\RemoteUsername");
    connectoptions.Password = "remoteComputersPasssword";
    
    ManagementScope scope = new ManagementScope(@"\\" + ipAddress + @"\root\cimv2");
    scope.Options = connectoptions;
    
    SelectQuery query = new SelectQuery("select * from Win32_Process where name = 'MYPROCESS.EXE'");
    
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    {
           ManagementObjectCollection collection = searcher.Get();
    
           if (collection.Count > 0)
           {
               foreach (ManagementObject mo in collection)
               {
                    uint processId = (uint)mo["ProcessId"];
                    string commandLine = (string) mo["CommandLine"];
    
                    string expectedCommandLine = string.Format("MYPROCESS.EXE {0} {1}", deviceId, deviceType);
    
                    if (commandLine != null && commandLine.ToUpper() == expectedCommandLine.ToUpper())
                    {
                         mo.InvokeMethod("Terminate", null);
                         break;
                    }
                }
           }
    }
