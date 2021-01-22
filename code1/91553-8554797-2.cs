        private void getServicesForDomainComputer(string computerName)
        {
            ConnectionOptions co1 = new ConnectionOptions();
            co1.Impersonation = ImpersonationLevel.Impersonate;
            //this query could also be: ("select * from Win32_Service where name = '" + serviceName + "'");
            ManagementScope scope = new ManagementScope(@"\\" + computerName + @"\root\cimv2");
            scope.Options = co1;
            SelectQuery query = new SelectQuery("select * from Win32_Service");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject service in collection)
                {
                    //the following are all of the available properties 
                    //boolean AcceptPause
                    //boolean AcceptStop
                    //string Caption
                    //uint32 CheckPoint
                    //string CreationClassName
                    //string Description
                    //boolean DesktopInteract
                    //string DisplayName
                    //string ErrorControl
                    //uint32 ExitCode;
                    //datetime InstallDate;
                    //string Name
                    //string PathName
                    //uint32 ProcessId
                    //uint32 ServiceSpecificExitCode
                    //string ServiceType
                    //boolean Started
                    //string StartMode
                    //string StartName
                    //string State
                    //string Status
                    //string SystemCreationClassName
                    //string SystemName;
                    //uint32 TagId;
                    //uint32 WaitHint;
                    if(service.Properties["Name"].Value.ToString() == "Apple Mobile Device")
                    {
                        service.Properties["StartMode"].Value = "Automatic";
                        
                    }
                }
            }         
        }
