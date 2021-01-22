    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GlobalMemoryStatusEx(MEMORYSTATUSEX lpBuffer);
    [StructLayout(LayoutKind.Sequential)]
    public sealed class MEMORYSTATUSEX {
      public uint dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
      public uint dwMemoryLoad;
      public ulong ullTotalPhys;
      public ulong ullAvailPhys;
      public ulong ullTotalPageFile;
      public ulong ullAvailPageFile;
      public ulong ullTotalVirtual;
      public ulong ullAvailVirtual;
      public ulong ullAvailExtendedVirtual;
    }
