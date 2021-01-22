        public static bool IsLocal(DirectoryInfo dir)
        {
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (string.Compare(dir.Root.FullName, d.Name, StringComparison.OrdinalIgnoreCase) == 0) //[drweb86] Fix for different case.
                {
                    return (d.DriveType != DriveType.Network);
                }
            }
             throw new DriveNotFoundException();
        }
