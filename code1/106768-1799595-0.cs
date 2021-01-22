        private static Regex _logicalDiskNameRegex = new Regex("(?<=\")[^\"]*(?=\")");
        private static Regex _partitionDiskIndexRegex = new Regex("(?<=\"Disk #)\\d+");
        public static Dictionary<string, string>[] GetPhisicalHardDiskToDriveLettersMap()
        {
            DriveInfo[] driveInfoArr = DriveInfo.GetDrives();
            DriveInfo lastDriveInfo = null;
            Dictionary<string, DriveInfo> driveInfos = new Dictionary<string, DriveInfo>(driveInfoArr.Length);
            foreach (DriveInfo driveInfo in driveInfoArr)
            {
                if (driveInfo.DriveType == DriveType.Fixed)
                {
                    driveInfos.Add(driveInfo.Name.Substring(0, 2), driveInfo);
                    lastDriveInfo = driveInfo;
                }
            }
            if (driveInfos.Count == 1 && lastDriveInfo != null)
            {
                return new Dictionary<string, string>[]
            {
                new Dictionary<string, string>()
                {
                    {lastDriveInfo.Name.Substring(0, 2), lastDriveInfo.DriveFormat}
                }
            };
            }
            Dictionary<string, Dictionary<string, string>> results = new Dictionary<string, Dictionary<string, string>>();
            using (ManagementClass partLogicalMap = new ManagementClass("Win32_LogicalDiskToPartition"))
            {
                using (ManagementObjectCollection partLogicalIns = partLogicalMap.GetInstances())
                {
                    foreach (ManagementObject diskDrive in partLogicalIns)
                    {
                        bool lazySuccess = false;
                        string driveName = null;
                        string driveFileSystem = null;
                        string physicalHardDisk = null;
                        string logicalDiskPath = (string)diskDrive["Dependent"];
                        string partitionPath = (string)diskDrive["Antecedent"];
                        Trace.WriteLine(logicalDiskPath);
                        Trace.WriteLine(partitionPath);
                        Match logicalDiskNameMatch = _logicalDiskNameRegex.Match(logicalDiskPath);
                        
                        if (logicalDiskNameMatch.Success)
                        {
                            Match partitionDiskIndexMatch = _partitionDiskIndexRegex.Match(partitionPath);
                            if (partitionDiskIndexMatch.Success)
                            {
                                try
                                {
                                    driveName = logicalDiskNameMatch.Value;
                                    physicalHardDisk = partitionDiskIndexMatch.Value;
                                    driveFileSystem = driveInfos[driveName].DriveFormat;
                                    lazySuccess = true;
                                }
                                catch (Exception ex)
                                {
                                    Trace.WriteLine(ex.ToString());
                                }
                            }
                        }
                        if (!lazySuccess)
                        {
                            // old good code but less performance, to be on the safe side if lazy method fails.
                            ManagementObject logicalDiskObject = new ManagementObject(logicalDiskPath);
                            ManagementObject partitionObject = new ManagementObject(partitionPath);
                            driveName = (string)logicalDiskObject["Name"];
                            driveFileSystem = (string)logicalDiskObject["FileSystem"];
                            physicalHardDisk = partitionObject["DiskIndex"].ToString();
                        }
                        Dictionary<string, string> hardDiskDrives;
                        
                        if (!results.TryGetValue(physicalHardDisk, out hardDiskDrives))
                        {
                            hardDiskDrives = new Dictionary<string, string>();
                            results.Add(physicalHardDisk, hardDiskDrives);
                        }
                        hardDiskDrives.Add(driveName, driveFileSystem);
                    }
                }
            }
            return ToArray(results.Values);
        }
