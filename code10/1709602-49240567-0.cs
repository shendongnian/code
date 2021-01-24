    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Management;
    using System.Net.NetworkInformation;
    using System.Runtime.InteropServices;
    
    namespace STUFF
    {
        public static class WorkStation
        {
            public const ulong MEGABYTE = 1024 * 1024;
            public const ulong GIGABYTE = 1024 * 1024 * 1024;
    
            #region MEMORYSTATUSEX
            /// <summary>
            /// contains information about the current state of both physical and virtual memory, including extended memory
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public class MEMORYSTATUSEX
            {
                /// <summary>
                /// Size of the structure, in bytes. You must set this member before calling GlobalMemoryStatusEx.
                /// </summary>
                public uint dwLength;
    
                /// <summary>
                /// Number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory use and 100 indicates full memory use).
                /// </summary>
                public uint dwMemoryLoad;
    
                /// <summary>
                /// Total size of physical memory, in bytes.
                /// </summary>
                public ulong ullTotalPhys;
    
                /// <summary>
                /// Size of physical memory available, in bytes.
                /// </summary>
                public ulong ullAvailPhys;
    
                /// <summary>
                /// Size of the committed memory limit, in bytes. This is physical memory plus the size of the page file, minus a small overhead.
                /// </summary>
                public ulong ullTotalPageFile;
    
                /// <summary>
                /// Size of available memory to commit, in bytes. The limit is ullTotalPageFile.
                /// </summary>
                public ulong ullAvailPageFile;
    
                /// <summary>
                /// Total size of the user mode portion of the virtual address space of the calling process, in bytes.
                /// </summary>
                public ulong ullTotalVirtual;
    
                /// <summary>
                /// Size of unreserved and uncommitted memory in the user mode portion of the virtual address space of the calling process, in bytes.
                /// </summary>
                public ulong ullAvailVirtual;
    
                /// <summary>
                /// Size of unreserved and uncommitted memory in the extended portion of the virtual address space of the calling process, in bytes.
                /// </summary>
                public ulong ullAvailExtendedVirtual;
    
                /// <summary>
                /// Initializes a new instance of the <see cref="T:MEMORYSTATUSEX"/> class.
                /// </summary>
                public MEMORYSTATUSEX()
                {
                    this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
                }
            }
            #endregion
    
            #region GlobalMemoryStatusEx
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
            #endregion      
    
            #region GetSystemMetrics
            private const UInt16 SM_SERVERR2 = 89;
    
            [DllImport("user32.dll")]
            static extern int GetSystemMetrics([In] UInt16 smIndex);
            #endregion
           
            public static List<string> GetCPUInfo()
            {
                List<string> res = new List<string>();
    
                ManagementScope Scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\cimv2");
                ObjectQuery Query = new ObjectQuery("SELECT Name FROM Win32_Processor");
                ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
                ManagementObjectCollection CollectionOfResults = Searcher.Get();
    
                res.Add(string.Format("{0} Processor(s)", Environment.ProcessorCount));
                foreach (ManagementObject CurrentObject in CollectionOfResults)
                {
                    res.Add(CurrentObject["Name"].ToString());
                }
    
                return res;
            }
    
            public static List<string> GetDriveInfo()
            {
                List<string> res = new List<string>();
    
                DriveInfo[] dirs = DriveInfo.GetDrives();
                foreach (DriveInfo dir in dirs)
                {
                    if ((dir.DriveType == DriveType.Fixed) && (dir.IsReady == true))
                    {
                        res.Add(string.Format("Size of {0}: {1} GB", dir.Name, ((ulong)dir.TotalSize / GIGABYTE).ToString()));
                        res.Add(string.Format("Total Free Space: {0} GB", ((ulong)dir.TotalFreeSpace / GIGABYTE).ToString()));
                        res.Add(string.Format("Available Free Space: {0} GB", ((ulong)dir.AvailableFreeSpace / GIGABYTE).ToString()));
                    }
                }
    
                return res;
            }
    
            public static List<string> GetGlobalizationInfo()
            {
                List<string> res = new List<string>();
    
                CultureInfo cultureInfo = CultureInfo.CurrentCulture;
                RegionInfo regionInfo = RegionInfo.CurrentRegion;
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
    
                res.Add(string.Format("Culture: {0}", cultureInfo.EnglishName));
                res.Add(string.Format("Region: {0}", regionInfo.EnglishName));
                res.Add(string.Format("Time Zone: {0}", timeZoneInfo.Id));
                res.Add(string.Format("Daylight Savings Enabled: {0}", timeZoneInfo.SupportsDaylightSavingTime));
                res.Add(string.Format("In Daylight Savings: {0}", timeZoneInfo.IsDaylightSavingTime(DateTime.Now)));
    
                return res;
            }
    
            public static List<string> GetMemoryStatus()
            {
                List<string> res = new List<string>();
    
                MEMORYSTATUSEX msx = new MEMORYSTATUSEX();
    
                try
                {
                    GlobalMemoryStatusEx(msx);
    
                    double total = Math.Round((double)msx.ullTotalPhys / GIGABYTE, 2, MidpointRounding.AwayFromZero);
                    double available = Math.Round((double)msx.ullAvailPhys / GIGABYTE, 2, MidpointRounding.AwayFromZero);
                    double inUse = Math.Round((double)(msx.ullTotalPhys - msx.ullAvailPhys) / GIGABYTE, 2, MidpointRounding.AwayFromZero);
    
                    res.Add(string.Format("Memory Load: {0}", msx.dwMemoryLoad));
                    res.Add(string.Format("Total Physical (GB): {0}", total));
                    res.Add(string.Format("In use (GB): {0}", inUse));
                    res.Add(string.Format("Available (GB): {0}", available));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
    
                return res;
            }
    
            public static MachineInformation GetMachineInformation()
            {
                MachineInformation mi = new MachineInformation();
    
                try
                {
                    ManagementClass osClass = new ManagementClass("Win32_OperatingSystem");
                    foreach (ManagementObject queryObj in osClass.GetInstances())
                    {
                        foreach (PropertyData prop in queryObj.Properties)
                        {
                            switch(prop.Name)
                            {
                                case "Caption":
                                    mi.Caption = prop.Value.ToString();
                                    break;
                                case "LastBootUpTime":
                                    mi.LastBootUpTime = prop.Value.ToString();
                                    break;
                                case "Locale":
                                    mi.Locale = prop.Value.ToString();
                                    break;
                                case "SerialNumber":
                                    mi.SerialNumber = prop.Value.ToString();
                                    break;
                                case "Version":
                                    mi.Version = prop.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                catch 
                {
                   // We don't care if this fails....info is not critical
                }
    
                return mi;
            }
            
            public static List<string> GetMacAddresses()
            {
                List<string> res = new List<string>();
    
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface ni in interfaces)
                    {
                        byte[] macAddress = ni.GetPhysicalAddress().GetAddressBytes();
                        if (macAddress.Length == 6)
                        {
                            if (macAddress[0] != 0 ||
                                macAddress[1] != 0 ||
                                macAddress[2] != 0 ||
                                macAddress[3] != 0 ||
                                macAddress[4] != 0 ||
                                macAddress[5] != 0)
                            {
                                res.Add(string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}",
                                    macAddress[0], macAddress[1], macAddress[2],
                                    macAddress[3], macAddress[4], macAddress[5]));
                            }
                        }
                    }
                }
    
                return res;
            }
        }
    }
