    public double GetTotalHDDSize(string driveName)
    {
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady && drive.Name == driveName)
            {
                return drive.TotalSize / (1024 * 1024 * 1024);
            }
        }
        return -1;
    }
