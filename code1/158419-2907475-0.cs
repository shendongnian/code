    public static string GetDefaultUserProfilePath() {
    	string path = System.Environment.GetEnvironmentVariable("DEFAULTUSERPROFILE") ?? string.Empty;
    	if (path.Length == 0) {
    		using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList")) {
    			path = (string)key.GetValue("Default", string.Empty);
    		}
    	}
    	return path;
    }
