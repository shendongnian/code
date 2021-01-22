    using System.IO;
    long long GetTotalFreeSpace(string driveName)
    {
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady && drive.Name == driveName)
            {
                return label.TotalFreeSpace;
            }
        }
        return -1;
    }
