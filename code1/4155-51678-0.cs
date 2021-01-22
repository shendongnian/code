    using System.IO;
    public static class GetDrives
    {
        public static IEnumerable<DriveInfo> GetCDDVDAndRemovableDevices()
        {
            return DriveInfo.GetDrives().
                Where(d => d.DriveType == DriveType.Removable
                && d.DriveType == DriveType.CDRom);
        }
      
    }
