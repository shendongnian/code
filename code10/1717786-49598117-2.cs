    public static bool IWindowsServerOver2012()
    {
		if (!IsWindowsServer()) return false;
		var osVersion = Environment.OSVersion.Version;
		return osVersion.Major > 6 || (osVersion.Major == 6 && osVersion.Minor >= 2);
	}
