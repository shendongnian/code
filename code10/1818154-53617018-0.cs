                ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OfflineFilesItem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    var pinInfo = (ManagementBaseObject)m.GetPropertyValue("PinInfo");
                    
                    if (pinInfo != null)
                    {
                        if ((bool)pinInfo.GetPropertyValue("Pinned"))
                        {
                              //the file or folder is set to "always available offline"
                              var itemPath = m["ItemPath"]
                        }
                    }
                }
