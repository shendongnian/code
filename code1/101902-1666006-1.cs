    using System.IO;
    
    DriveInfo[] allDrives = DriveInfo.GetDrives();
    foreach (DriveInfo d in allDrives)
    {
      if (d.IsReady && d.DriveType == DriveType.Fixed)
      {
        // This is the drive you want...
      }
    }
