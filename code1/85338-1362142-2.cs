    internal class ClrDump
    {
      [return: MarshalAs(UnmanagedType.Bool)]
      [DllImport("clrdump.dll", CharSet=CharSet.Unicode, SetLastError=true)]
      public static extern bool CreateDump(uint ProcessId, string FileName, MINIDUMP_TYPE DumpType, uint ExcThreadId, IntPtr ExtPtrs);
      [return: MarshalAs(UnmanagedType.Bool)]
      [DllImport("clrdump.dll", CharSet=CharSet.Unicode, SetLastError=true)]
      public static extern bool RegisterFilter(string FileName, MINIDUMP_TYPE DumpType);
      [DllImport("clrdump.dll")]
      public static extern FILTER_OPTIONS SetFilterOptions(FILTER_OPTIONS Options);
      [return: MarshalAs(UnmanagedType.Bool)]
      [DllImport("clrdump.dll", SetLastError=true)]
      public static extern bool UnregisterFilter();
    
      [Flags]
      public enum FILTER_OPTIONS
      {
        CLRDMP_OPT_CALLDEFAULTHANDLER = 1
      }
    
      [Flags]
      public enum MINIDUMP_TYPE
      {
        MiniDumpFilterMemory = 8,
        MiniDumpFilterModulePaths = 0x80,
        MiniDumpNormal = 0,
        MiniDumpScanMemory = 0x10,
        MiniDumpWithCodeSegs = 0x2000,
        MiniDumpWithDataSegs = 1,
        MiniDumpWithFullMemory = 2,
        MiniDumpWithFullMemoryInfo = 0x800,
        MiniDumpWithHandleData = 4,
        MiniDumpWithIndirectlyReferencedMemory = 0x40,
        MiniDumpWithoutManagedState = 0x4000,
        MiniDumpWithoutOptionalData = 0x400,
        MiniDumpWithPrivateReadWriteMemory = 0x200,
        MiniDumpWithProcessThreadData = 0x100,
        MiniDumpWithThreadInfo = 0x1000,
        MiniDumpWithUnloadedModules = 0x20
      }
    }
