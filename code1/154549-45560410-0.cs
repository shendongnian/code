    static readonly bool Is64BitProcess = IntPtr.Size.Equals(8);
    static readonly bool Is64BitOperatingSystem = Is64BitProcess || InternalCheckIsWow64();
    
    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWow64Process(
    	[In] IntPtr hProcess,
    	[Out] out bool wow64Process
    );
    
    private static bool InternalCheckIsWow64()
    {
    	if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1 ||
    		Environment.OSVersion.Version.Major >= 6)
    	{
    		using (Process p = Process.GetCurrentProcess())
    		{
    			bool retVal;
    			if (!IsWow64Process(p.Handle, out retVal))
    			{
    				return false;
    			}
    			return retVal;
    		}
    	}
    	return false;
    }
    
    private static string HKLM_GetString(string key, string value)
    {
    	try
    	{
    		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key);
    		return registryKey?.GetValue(value).ToString() ?? String.Empty;
    	}
    	catch
    	{
    		return String.Empty;
    	}
    }
    
    public static string GetWindowsVersion()
    {
    	string osArchitecture;
    	try
    	{
    		osArchitecture = Is64BitOperatingSystem ? "64-bit" : "32-bit";
    	}
    	catch (Exception)
    	{
    		osArchitecture = "32/64-bit (Undetermined)";
    	}
    	string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
    	string csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
    	string currentBuild = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber");
    	if (!string.IsNullOrEmpty(productName))
    	{
    		return
    			$"{productName}{(!string.IsNullOrEmpty(csdVersion) ? " " + csdVersion : String.Empty)} {osArchitecture} (OS Build {currentBuild})";
    	}
    	return String.Empty;
    }
