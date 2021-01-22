        public static bool IsLocal(DirectoryInfo dir)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (string.Compare(dir.Root.FullName, d.Name, StringComparison.OrdinalIgnoreCase) == 0) //[drweb86] Fix for different case.
                {
                    if (d.DriveType == DriveType.Network)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }    
                }
            }
             throw new DriveNotFoundException();
        }
