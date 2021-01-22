    public string GetUserName1()
            {
                
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT UserName FROM Win32_ComputerSystem");
                string user = string.Empty;
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    user = Convert.ToString(queryObj["UserName"]);
                    
                }
    
                return user;
                
            }
