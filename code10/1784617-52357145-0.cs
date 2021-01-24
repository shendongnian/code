            const String k_freeSpace = "System.FreeSpace";
            const String k_totalSpace = "System.Capacity";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    Debug.WriteLine("Drive: " + d.Name);
                    Debug.WriteLine("RootDir: " + d.RootDirectory.FullName);
                    StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(d.RootDirectory.FullName);
                    var props = await folder.Properties.RetrievePropertiesAsync(new string[] { k_freeSpace, k_totalSpace });
                    Debug.WriteLine("FreeSpace: " + (UInt64)props[k_freeSpace]);
                    Debug.WriteLine("Capacity:  " + (UInt64)props[k_totalSpace]);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(String.Format("Couldn't get info for drive {0}.  Does it have media in it?", d.Name));
                }
            }
