Visual Studio Pro 15.7.6 - 15.8.5
.Net Framework Core 2.1
C# 6.0 -> 7.3
.Net System.Management 4.5
    using System.Management;
    public class SystemUSBDrives
    {
        string m_ComputerName = string.Empty;
        public SystemUSBDrives(string ComputerName)
        {
            this.m_ComputerName = string.IsNullOrEmpty(ComputerName)
                                ? Environment.MachineName
                                : ComputerName;
        }
        public class USBDriveInfo
        {
            public bool Bootable { get; private set; }
            public bool BootPartition { get; private set; }
            public string Caption { get; private set; }
            public string DeviceID { get; private set; }
            public UInt32 DiskIndex { get; private set; }
            public string FileSystem { get; private set; }
            public string FirmwareRevision { get; private set; }
            public UInt64 FreeSpace { get; private set; }
            public string InterfaceType { get; private set; }
            public string LogicalDisk { get; private set; }
            public bool MediaLoaded { get; private set; }
            public string MediaType { get; private set; }
            public string Model { get; private set; }
            public UInt32 Partitions { get; private set; }
            public UInt64 PartitionBlockSize { get; private set; }
            public UInt64 PartitionNumberOfBlocks { get; private set; }
            public UInt64 PartitionStartingOffset { get; private set; }
            public string PNPDeviceID { get; private set; }
            public bool PrimaryPartition { get; private set; }
            public string SerialNumber { get; private set; }
            public UInt64 Size { get; private set; }
            public string Status { get; private set; }
            public bool SupportsDiskQuotas { get; private set; }
            public UInt64 TotalCylinders { get; private set; }
            public UInt32 TotalHeads { get; private set; }
            public UInt64 TotalSectors { get; private set; }
            public UInt64 TotalTracks { get; private set; }
            public UInt32 TracksPerCylinder { get; private set; }
            public string VolumeName { get; private set; }
            public string VolumeSerialNumber { get; private set; }
            public void GetDiskDriveInfo(ManagementObject DiskDrive)
            {
                this.Caption = DiskDrive["Caption"]?.ToString();
                this.DeviceID = DiskDrive["DeviceID"]?.ToString();
                this.FirmwareRevision = DiskDrive["FirmwareRevision"]?.ToString();
                this.InterfaceType = DiskDrive["InterfaceType"]?.ToString();
                this.MediaLoaded = (bool?)DiskDrive["MediaLoaded"] ?? false;
                this.MediaType = DiskDrive["MediaType"]?.ToString();
                this.Model = DiskDrive["Model"]?.ToString();
                this.Partitions = (UInt32?)DiskDrive["Partitions"] ?? 0;
                this.PNPDeviceID = DiskDrive["PNPDeviceID"]?.ToString();
                this.SerialNumber = DiskDrive["SerialNumber"]?.ToString();
                this.Size = (UInt64?)DiskDrive["Size"] ?? 0L;
                this.Status = DiskDrive["Status"]?.ToString();
                this.TotalCylinders = (UInt64?)DiskDrive["TotalCylinders"] ?? 0;
                this.TotalHeads = (UInt32?)DiskDrive["TotalHeads"] ?? 0U;
                this.TotalSectors = (UInt64?)DiskDrive["TotalSectors"] ?? 0;
                this.TotalTracks = (UInt64?)DiskDrive["TotalTracks"] ?? 0;
                this.TracksPerCylinder = (UInt32?)DiskDrive["TracksPerCylinder"] ?? 0;
            }
            public void GetDiskPartitionInfo(ManagementObject Partitions)
            {
                this.Bootable = (bool?)Partitions["Bootable"] ?? false;
                this.BootPartition = (bool?)Partitions["BootPartition"] ?? false;
                this.DiskIndex = (UInt32?)Partitions["DiskIndex"] ?? 0;
                this.PartitionBlockSize = (UInt64?)Partitions["BlockSize"] ?? 0;
                this.PartitionNumberOfBlocks = (UInt64?)Partitions["NumberOfBlocks"] ?? 0;
                this.PrimaryPartition = (bool?)Partitions["PrimaryPartition"] ?? false;
                this.PartitionStartingOffset = (UInt64?)Partitions["StartingOffset"] ?? 0;
            }
            public void GetLogicalDiskInfo(ManagementObject LogicalDisk)
            {
                this.FileSystem = LogicalDisk["FileSystem"]?.ToString();
                this.FreeSpace = (UInt64?)LogicalDisk["FreeSpace"] ?? 0;
                this.LogicalDisk = LogicalDisk["DeviceID"]?.ToString();
                this.SupportsDiskQuotas = (bool?)LogicalDisk["SupportsDiskQuotas"] ?? false;
                this.VolumeName = LogicalDisk["VolumeName"]?.ToString();
                this.VolumeSerialNumber = LogicalDisk["VolumeSerialNumber"]?.ToString();
            }
        }
        public List<USBDriveInfo> GetUSBDrivesInfo(string UserName, string Password, string Domain)
        {
            List<USBDriveInfo> WMIQueryResult = new List<USBDriveInfo>();
            ConnectionOptions ConnOptions = GetConnectionOptions(UserName, Password, Domain);
            EnumerationOptions mOptions = GetEnumerationOptions(false);
            ManagementScope mScope = new ManagementScope(@"\\" + this.m_ComputerName + @"\root\CIMV2", ConnOptions);
            SelectQuery selQuery = new SelectQuery("SELECT * FROM Win32_DiskDrive " +
                                                    "WHERE InterfaceType='USB'");
            mScope.Connect();
            using (ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(mScope, selQuery, mOptions))
            {
                foreach (ManagementObject moDiskDrive in moSearcher.Get())
                {
                    USBDriveInfo usbInfo = new USBDriveInfo();
                    usbInfo.GetDiskDriveInfo(moDiskDrive);
                    var relQuery = new RelatedObjectQuery("Associators of {Win32_DiskDrive.DeviceID='" +
                                                          moDiskDrive.Properties["DeviceID"].Value.ToString() + "'} " +
                                                          "where AssocClass=Win32_DiskDriveToDiskPartition");
                    using (ManagementObjectSearcher moAssocPart = new ManagementObjectSearcher(mScope, relQuery, mOptions))
                    {
                        foreach (ManagementObject moAssocPartition in moAssocPart.Get())
                        {
                            usbInfo.GetDiskPartitionInfo(moAssocPartition);
                            relQuery = new RelatedObjectQuery("Associators of {Win32_DiskPartition.DeviceID='" +
                                                              moAssocPartition.Properties["DeviceID"].Value.ToString() + "'} " +
                                                              "where AssocClass=CIM_LogicalDiskBasedOnPartition");
                            using (ManagementObjectSearcher moLogDisk = new ManagementObjectSearcher(mScope, relQuery, mOptions))
                            {
                                foreach (ManagementObject moLogDiskEnu in moLogDisk.Get())
                                {
                                    usbInfo.GetLogicalDiskInfo(moLogDiskEnu);
                                    moLogDiskEnu.Dispose();
                                }
                            }
                            moAssocPartition.Dispose();
                        }
                        WMIQueryResult.Add(usbInfo);
                    }
                    moDiskDrive.Dispose();
                }
                return WMIQueryResult;
            }
        }   //GetUSBDrivesInfo()
        private ConnectionOptions GetConnectionOptions(string UserName, string Password, string DomainAuthority)
        {
            ConnectionOptions ConnOptions = new ConnectionOptions()
            {
                EnablePrivileges = true,
                Timeout = ManagementOptions.InfiniteTimeout,
                Authentication = AuthenticationLevel.PacketPrivacy,
                Impersonation = ImpersonationLevel.Impersonate,
                Username = UserName,
                Password = Password,
                Authority = DomainAuthority  //Authority = "NTLMDOMAIN:[domain]"
            };
            return ConnOptions;
        }
        private System.Management.EnumerationOptions GetEnumerationOptions(bool DeepScan)
        {
            System.Management.EnumerationOptions mOptions = new System.Management.EnumerationOptions()
            {
                Rewindable = false,        //Forward only query => no caching
                ReturnImmediately = true,  //Pseudo-async result
                DirectRead = true,         //True => Direct access to the WMI provider, no super class or derived classes
                EnumerateDeep = DeepScan   //False => only immediate derived class members are returned.
            };
            return mOptions;
        }
    }  //SystemUSBDrives
