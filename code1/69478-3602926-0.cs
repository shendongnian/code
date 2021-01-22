    private static bool DriveSetForReconnect(string ComputerName, string DriveLetter)
    {
        RegistryKey key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, ComputerName);
        key = key.OpenSubKey("Network\\" + DriveLetter);
        return key != null;
    }
