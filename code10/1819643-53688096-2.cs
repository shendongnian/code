    string MachineName = "[Name]";
                string TargetService = "NHS Card Checker";
    
                {
                    ConnectionOptions options = new ConnectionOptions();
                        options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
                        ManagementScope scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", MachineName));
                        scope.Connect();
    
                        string wmiQuery = String.Format("Select * from Win32_Service WHERE DisplayName='{0}'", TargetService);
    
                        ManagementObjectSearcher wmi = new ManagementObjectSearcher(wmiQuery);
                        ManagementObjectCollection coll = wmi.Get();
    
                        if (coll.Count > 0)
                        {
    
                            foreach (var service in coll)
                            {
                                Console.WriteLine(string.Format("NHS Card checker found on MPC - Status: {0}", service["Status"].ToString()));
                                Console.WriteLine(string.Format("{0} - {1}", service["Name"].ToString(), service["StartMode"].ToString()));
                            }
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} Service was not found", TargetService));
                        }
    
                    }
                }
