    using System;
    using System.Management;
    
    ManagementObject disk = new
    ManagementObject("win32_logicaldisk.deviceid="c:"");
    disk.Get();
    Console.WriteLine("Logical Disk Size = " + disk["Size"] + " bytes");
    Console.WriteLine("Logical Disk FreeSpace = " + disk["FreeSpace"] + "
    bytes"); 
