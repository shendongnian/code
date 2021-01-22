    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SYSTEM_INFO
    {
      public ushort wProcessorArchitecture;
      public ushort wReserved;
      public uint dwPageSize;
      public IntPtr lpMinimumApplicationAddress;
      public IntPtr lpMaximumApplicationAddress;
      public IntPtr dwActiveProcessorMask;
      public uint dwNumberOfProcessors;
      public uint dwProcessorType;
      public uint dwAllocationGranularity;
      public ushort wProcessorLevel;
      public ushort wProcessorRevision;
    }
    internal static class SystemInfo 
    {
        static int _trueNumberOfProcessors;
        internal static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);    
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern void GetSystemInfo(out SYSTEM_INFO si);
        [DllImport("kernel32.dll")]
        internal static extern int GetProcessAffinityMask(IntPtr handle, out IntPtr processAffinityMask, out IntPtr systemAffinityMask);
        internal static int GetNumProcessCPUs()
        {
          if (SystemInfo._trueNumberOfProcessors == 0)
          {
            SYSTEM_INFO si;
            GetSystemInfo(out si);
            if ((int) si.dwNumberOfProcessors == 1)
            {
              SystemInfo._trueNumberOfProcessors = 1;
            }
            else
            {
              IntPtr processAffinityMask;
              IntPtr systemAffinityMask;
              if (GetProcessAffinityMask(INVALID_HANDLE_VALUE, out processAffinityMask, out systemAffinityMask) == 0)
              {
                SystemInfo._trueNumberOfProcessors = 1;
              }
              else
              {
                int num1 = 0;
                if (IntPtr.Size == 4)
                {
                  uint num2 = (uint) (int) processAffinityMask;
                  while ((int) num2 != 0)
                  {
                    if (((int) num2 & 1) == 1)
                      ++num1;
                    num2 >>= 1;
                  }
                }
                else
                {
                  ulong num2 = (ulong) (long) processAffinityMask;
                  while ((long) num2 != 0L)
                  {
                    if (((long) num2 & 1L) == 1L)
                      ++num1;
                    num2 >>= 1;
                  }
                }
                SystemInfo._trueNumberOfProcessors = num1;
              }
            }
          }
          return SystemInfo._trueNumberOfProcessors;
        }
    }
