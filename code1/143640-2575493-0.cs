    private static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);
    }
    public static int ProcessorCount
    {
        get
        {
            NativeMethods.SYSTEM_INFO lpSystemInfo = new NativeMethods.SYSTEM_INFO();
            NativeMethods.GetNativeSystemInfo(ref lpSystemInfo);
            return (int)lpSystemInfo.dwNumberOfProcessors;
        }
    }
