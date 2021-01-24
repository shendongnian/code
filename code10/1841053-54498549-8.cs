    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MEMORYSTATUSEX
    {
        public uint dwLength;
        /// <summary> Number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory use and 100 indicates full memory use). </summary>
        public uint dwMemoryLoad;
        /// <summary> Total size of physical memory, in bytes. </summary>
        public ulong ullTotalPhys;
        /// <summary> Size of physical memory available, in bytes. </summary>
        public ulong ullAvailPhys;
        /// <summary> Size of the committed memory limit, in bytes. This is physical memory plus the size of the page file, minus a small overhead. </summary>
        public ulong ullTotalPageFile;
        /// <summary> Size of available memory to commit, in bytes. The limit is ullTotalPageFile. </summary>
        public ulong ullAvailPageFile;
        /// <summary> Total size of the user mode portion of the virtual address space of the calling process, in bytes. </summary>
        public ulong ullTotalVirtual;
        /// <summary> Size of unreserved and uncommitted memory in the user mode portion of the virtual address space of the calling process, in bytes. </summary>
        public ulong ullAvailVirtual;
        /// <summary> Size of unreserved and uncommitted memory in the extended portion of the virtual address space of the calling process, in bytes. </summary>
        public ulong ullAvailExtendedVirtual;
        /// <summary> Initializes a new instance of the <see cref="T:MEMORYSTATUSEX"/> class. </summary>
        public MEMORYSTATUSEX() => this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
    }
    public static MEMORYSTATUSEX GetSystemMemoryStatus()
    {
        MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
        GlobalMemoryStatusEx(memoryStatus);
        return memoryStatus;
    }
