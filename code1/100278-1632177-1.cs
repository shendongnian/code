    public static DateTime GetLastSystemShutdown()
    {
        string sKey = @"System\CurrentControlSet\Control\Windows";
        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey);
        string sValueName = "ShutdownTime";
        byte[] val = (byte[]) key.GetValue(sValueName);
        long valueAsLong = BitConverter.ToInt64(val, 0);
        return DateTime.FromFileTime(valueAsLong);
    }
