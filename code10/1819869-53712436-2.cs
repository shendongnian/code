    using System.Collections.Generic
    using System.Management;
    public static List<string> GetDriveLettersForSerialNumber(string driveSerialNumber)
    {        
        var results = new List<string>();
        if (driveSerialNumber == null) return results;
        var drive = new ManagementObjectSearcher(
            "SELECT DeviceID, SerialNumber, Partitions FROM Win32_DiskDrive").Get()
            .Cast<ManagementObject>()
            .FirstOrDefault(device =>
                device["SerialNumber"].ToString().Trim()
                    .Equals(driveSerialNumber.Trim(), StringComparison.OrdinalIgnoreCase));
        if (drive == null) return results;
        var partitions = new ManagementObjectSearcher(
            $"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{drive["DeviceID"]}'}} " +
            "WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get();
        foreach (var partition in partitions)
        {
            var logicalDrives = new ManagementObjectSearcher(
                "ASSOCIATORS OF {{Win32_DiskPartition.DeviceID=" + 
                $"'{partition["DeviceID"]}'}} " +
                "WHERE AssocClass = Win32_LogicalDiskToPartition").Get();
            foreach (var logicalDrive in logicalDrives)
            {
                var volumes = new ManagementObjectSearcher(
                    "SELECT Name FROM Win32_LogicalDisk WHERE " +
                    $"Name='{logicalDrive["Name"]}'").Get().Cast<ManagementObject>();
                results.AddRange(volumes.Select(v => v["Name"].ToString()));
            }
        }
        return results;
    }
