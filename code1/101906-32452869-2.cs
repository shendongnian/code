    //Add Reference System.Management and use namespace at the top of the code.
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                foreach (ManagementObject b in queryObj.GetRelated("Win32_DiskPartition"))
                {
                    foreach (ManagementBaseObject c in b.GetRelated("Win32_LogicalDisk"))
                    { 
                        Console.WriteLine(String.Format("{0}" + "\\", c["Name"].ToString())); // here it will print USB drive letter
                    }
                }
            }
