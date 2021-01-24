        private static string GetTotalFreeSpace(string driveName)
         {
           foreach (DriveInfo drive in DriveInfo.GetDrives())
           {
               if (drive.IsReady && drive.Name == driveName)
               {
                 string TotalSize = (drive.TotalSize / (1024.0 * 1024.0 * 1024.0)).ToString("0");
                 string FreeSize = (drive.TotalFreeSpace / (1024.0 * 1024.0 * 1024.0)).ToString("0");
                  return string.Format( drive.Name + " Drive Total size is {0} GB Free size is {1} GB",TotalSize,FreeSize);
               }
           }
          return null;
        }
