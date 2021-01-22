        public static ulong GetFreeSpaceOfPathInBytes(string path)
        {
            if ((new Uri(path)).IsUnc)
            {
                throw new NotImplementedException("Cannot find free space for UNC path " + path);
            }
            ulong freeSpace = 0;
            int prevVolumeNameLength = 0;
            foreach (ManagementObject volume in
                    new ManagementObjectSearcher("Select * from Win32_Volume").Get())
            {
                if (UInt32.Parse(volume["DriveType"].ToString()) > 1 &&                             // Is Volume monuted on host
                    volume["Name"] != null &&                                                       // Volume has a root directory
                    path.StartsWith(volume["Name"].ToString(), StringComparison.OrdinalIgnoreCase)  // Required Path is under Volume's root directory 
                    )
                {
                    // If multiple volumes have their root directory matching the required path,
                    // one with most nested (longest) Volume Name is given preference.
                    // Case: CSV volumes monuted under other drive volumes.
                    int currVolumeNameLength = volume["Name"].ToString().Length;
                    if ((prevVolumeNameLength == 0 || currVolumeNameLength > prevVolumeNameLength) &&
                        volume["FreeSpace"] != null
                        )
                    {
                        freeSpace = ulong.Parse(volume["FreeSpace"].ToString());
                        prevVolumeNameLength = volume["Name"].ToString().Length;
                    }
                }
            }
            if (prevVolumeNameLength > 0)
            {
                return freeSpace;
            }
            throw new Exception("Could not find Volume Information for path " + path);
        }
