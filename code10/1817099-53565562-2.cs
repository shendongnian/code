    //ManagementObject sys = new ManagementObject("Win32_OperatingSystem=@");
    //string systemDrive = sys["SystemDrive"].ToString();
    //Console.WriteLine("System Drive is {0}", systemDrive);
    string strQuery = "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID=\"" 
                    + System.IO.Path.GetPathRoot(Environment.SystemDirectory).Replace("\\", "") 
                    + "\"} WHERE AssocClass = Win32_LogicalDiskToPartition";
    RelatedObjectQuery relquery = new RelatedObjectQuery(strQuery);
    ManagementObjectSearcher search = new ManagementObjectSearcher(relquery);
    UInt32 ndx = 0;
    foreach (var diskPartition in search.Get())
    {
        ndx = (uint)diskPartition["DiskIndex"];
        Console.WriteLine("Disk Index of System Drive is {0}, Disk Partition is {1}", ndx, diskPartition["DeviceID"]);
    }
    SelectQuery diskQuery = new SelectQuery(string.Format("SELECT * FROM Win32_DiskDrive WHERE Index={0}", ndx));
    ManagementObjectSearcher diskSearch = new ManagementObjectSearcher(diskQuery);
    foreach (var disk in diskSearch.Get())
    {
        Console.WriteLine("Caption is {0}", disk["Caption"]);
        Console.WriteLine("Serial Number is {0}", disk["SerialNumber"]);
        Console.WriteLine("Model is {0}", disk["Model"]);
        Console.WriteLine("InterfaceType is {0}", disk["InterfaceType"]);
    }
