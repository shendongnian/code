            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    foreach (ManagementObject o in queryObj.GetRelated("Win32_DiskPartition"))
                    {
                        foreach (ManagementBaseObject b in o.GetRelated("Win32_LogicalDisk"))
                        {
                            Debug.WriteLine("    #Name: {0}", b["Name"]);
                        }
                    }
                    Debug.WriteLine("Interface: {0}", queryObj["InterfaceType"]); // One of: USB, IDE
                    Debug.WriteLine("--------------------------------------------");
                }
            }
            catch (ManagementException f)
            {
                Debug.WriteLine(f.StackTrace);
            }
