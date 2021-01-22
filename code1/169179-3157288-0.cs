    i am using following code to access mac address in format you want :
    
    public string GetSystemMACID()
            {
                string systemName = System.Windows.Forms.SystemInformation.ComputerName;
                try
                {
                    ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
                    ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
                    ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
                    ManagementObjectCollection theCollectionOfResults = theSearcher.Get();
    
                    foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                    {
                        if (theCurrentObject["MACAddress"] != null)
                        {
                            string macAdd = theCurrentObject["MACAddress"].ToString();
                            return macAdd.Replace(':', '-');
                        }
                    }
                }
                catch (ManagementException e)
                {
                               }
                catch (System.UnauthorizedAccessException e)
                {
                    
                }
                return string.Empty;
            }
