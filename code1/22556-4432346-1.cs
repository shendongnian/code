        public static bool IsLocal(DirectoryInfo dir)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (dir.Root.FullName.Equals (d.Name) )
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
            throw new Exception("drive not available");
        }
