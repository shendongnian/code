    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security;
    
    public class SystemMemoryInfo
    {
        private readonly PerformanceCounter _monoAvailableMemoryCounter;
        private readonly PerformanceCounter _monoTotalMemoryCounter;
        private readonly PerformanceCounter _netAvailableMemoryCounter;
    
        private ulong _availablePhysicalMemory;
        private ulong _totalPhysicalMemory;
    
        public SystemMemoryInfo()
        {
            try
            {
                if (PerformanceCounterCategory.Exists("Mono Memory"))
                {
                    _monoAvailableMemoryCounter = new PerformanceCounter("Mono Memory", "Available Physical Memory");
                    _monoTotalMemoryCounter = new PerformanceCounter("Mono Memory", "Total Physical Memory");
                }
                else if (PerformanceCounterCategory.Exists("Memory"))
                {
                    _netAvailableMemoryCounter = new PerformanceCounter("Memory", "Available Bytes");
                }
            }
            catch
            {
                // ignored
            }
        }
    
        public ulong AvailablePhysicalMemory
        {
            [SecurityCritical]
            get
            {
                Refresh();
    
                return _availablePhysicalMemory;
            }
        }
    
        public ulong TotalPhysicalMemory
        {
            [SecurityCritical]
            get
            {
                Refresh();
    
                return _totalPhysicalMemory;
            }
        }
    
        [SecurityCritical]
        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);
    
        [SecurityCritical]
        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);
    
        [SecurityCritical]
        private void Refresh()
        {
            try
            {
                if (_monoTotalMemoryCounter != null && _monoAvailableMemoryCounter != null)
                {
                    _totalPhysicalMemory = (ulong) _monoTotalMemoryCounter.NextValue();
                    _availablePhysicalMemory = (ulong) _monoAvailableMemoryCounter.NextValue();
                }
                else if (Environment.OSVersion.Version.Major < 5)
                {
                    var memoryStatus = MEMORYSTATUS.Init();
                    GlobalMemoryStatus(ref memoryStatus);
    
                    if (memoryStatus.dwTotalPhys > 0)
                    {
                        _availablePhysicalMemory = memoryStatus.dwAvailPhys;
                        _totalPhysicalMemory = memoryStatus.dwTotalPhys;
                    }
                    else if (_netAvailableMemoryCounter != null)
                    {
                        _availablePhysicalMemory = (ulong) _netAvailableMemoryCounter.NextValue();
                    }
                }
                else
                {
                    var memoryStatusEx = MEMORYSTATUSEX.Init();
    
                    if (GlobalMemoryStatusEx(ref memoryStatusEx))
                    {
                        _availablePhysicalMemory = memoryStatusEx.ullAvailPhys;
                        _totalPhysicalMemory = memoryStatusEx.ullTotalPhys;
                    }
                    else if (_netAvailableMemoryCounter != null)
                    {
                        _availablePhysicalMemory = (ulong) _netAvailableMemoryCounter.NextValue();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    
        private struct MEMORYSTATUS
        {
            private uint dwLength;
            internal uint dwMemoryLoad;
            internal uint dwTotalPhys;
            internal uint dwAvailPhys;
            internal uint dwTotalPageFile;
            internal uint dwAvailPageFile;
            internal uint dwTotalVirtual;
            internal uint dwAvailVirtual;
    
            public static MEMORYSTATUS Init()
            {
                return new MEMORYSTATUS
                {
                    dwLength = checked((uint) Marshal.SizeOf(typeof(MEMORYSTATUS)))
                };
            }
        }
    
        private struct MEMORYSTATUSEX
        {
            private uint dwLength;
            internal uint dwMemoryLoad;
            internal ulong ullTotalPhys;
            internal ulong ullAvailPhys;
            internal ulong ullTotalPageFile;
            internal ulong ullAvailPageFile;
            internal ulong ullTotalVirtual;
            internal ulong ullAvailVirtual;
            internal ulong ullAvailExtendedVirtual;
    
            public static MEMORYSTATUSEX Init()
            {
                return new MEMORYSTATUSEX
                {
                    dwLength = checked((uint) Marshal.SizeOf(typeof(MEMORYSTATUSEX)))
                };
            }
        }
    }
