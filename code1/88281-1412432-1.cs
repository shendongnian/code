    using System;
    using System.Management;
    public string GetFreeSpace();
    { 
       ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
       disk.Get();
       string freespace = disk["FreeSpace"];
       return freespace;
    }
