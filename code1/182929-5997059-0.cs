		public static bool Win7;
		[DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        #endregion OSVERSIONINFOEX
        
		static MyMethod () {
			
			Version ver = System.Environment.OSVersion.Version;
			OperatingSystem osVersion = Environment.OSVersion;
            OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
            osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));
            GetVersionEx(ref osVersionInfo);
			byte productType = osVersionInfo.wProductType;
			if (ver.Major==6 & ver.Minor==1 & productType==1) {
				Win7=true;
				}
			else {
				Win7=false;
				}
			if (ver.Major==6 & ver.Minor==1 & productType==3)
				Report.Info ("OS is Windows Server 2008 R2");
			else //here standart methods can be used...
				Report.Info ("ver.Major: "+ver.Major.ToString()+"\r\nver.Minor: "+ver.Minor.ToString()+"\r\nproductType: "+productType.ToString());
