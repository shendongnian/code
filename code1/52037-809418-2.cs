    public class AdjustTokenPrivilegesFunctionality
    {
      [StructLayout(LayoutKind.Sequential)]
      private struct LUID
      {
        public uint LowPart;
        public int HighPart;
      }
    
      [StructLayout(LayoutKind.Sequential)]
      private struct LUID_AND_ATTRIBUTES
      {
        public LUID Luid;
        public UInt32 Attributes;
      }
    
      private struct TOKEN_PRIVILEGES
      {
        public UInt32 PrivilegeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public LUID_AND_ATTRIBUTES[] Privileges;
      }
    
      public const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
      public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
      public const int TOKEN_QUERY = 0x00000008;
      public const int SE_PRIVILEGE_ENABLED = 0x00000002;
    
      [DllImport("advapi32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, UInt32 Zero, IntPtr Null1, IntPtr Null2);
    
      [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
      private static extern int OpenProcessToken(int ProcessHandle, int DesiredAccess, out IntPtr tokenhandle);
    
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern int GetCurrentProcess();
    
      [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
      private static extern int LookupPrivilegeValue(string lpsystemname, string lpname, [MarshalAs(UnmanagedType.Struct)] ref LUID lpLuid);
    
      static void EnableSetTimeZonePrivileges()
      {
        // We must add the set timezone privilege to the process token or SetTimeZoneInformation will fail
        IntPtr token;
        int retval = OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out token);
        Assert.IsTrue(retval != 0, String.Format("OpenProcessToken failed. GetLastError: {0}", Marshal.GetLastWin32Error()));
    
        LUID luid = new LUID();
        retval = LookupPrivilegeValue(null, SE_TIME_ZONE_NAME, ref luid);
        Assert.IsTrue(retval != 0, String.Format("LookupPrivilegeValue failed. GetLastError: {0}", Marshal.GetLastWin32Error()));
    
        TOKEN_PRIVILEGES tokenPrivs = new TOKEN_PRIVILEGES();
        tokenPrivs.PrivilegeCount = 1;
        tokenPrivs.Privileges = new LUID_AND_ATTRIBUTES[1];
        tokenPrivs.Privileges[0].Luid = luid;
        tokenPrivs.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
        Assert.IsTrue(AdjustTokenPrivileges(token, false, ref tokenPrivs, 0, IntPtr.Zero, IntPtr.Zero), String.Format("AdjustTokenPrivileges failed. GetLastError: {0}", Marshal.GetLastWin32Error()));
      }
    }
