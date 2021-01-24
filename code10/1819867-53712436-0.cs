    using System.Collections.Generic
    using System.Management;
    public static List<string> GetDriveLettersForSerialNumber(string serialNumber)
    {
        if (serialNumber == null) return null;
        var results = new List<string>();
        var drive = new ManagementObjectSearcher(
            "SELECT DeviceID, SerialNumber, Partitions FROM Win32_DiskDrive").Get()
            .Cast<ManagementObject>()
            .FirstOrDefault(d => d["SerialNumber"].ToString().Trim() == serialNumber.Trim());
        if (drive == null) return null;
        var partitions = new ManagementObjectSearcher(
            $"ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{drive["DeviceID"]}'}} " +
            "WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get();
        foreach (var partition in partitions)
        {
            var logicalDrives = new ManagementObjectSearcher(
                $"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} " +
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
