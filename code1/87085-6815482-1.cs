    using System.IO;
    private long GetTotalFreeSpace(string driveName)
    {
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady && drive.Name == driveName)
            {
                return drive.TotalFreeSpace;
            }
        }
        return -1;
    }
