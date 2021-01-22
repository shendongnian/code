    internal enum RegistryFlags
    {
        ...
        RegSz = 0x02,
        ...
        SubKeyWow6464Key = 0x00010000,
        ...
    }
    internal enum RegistryType
    {
        RegNone = 0,
        ...
    }
    [DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int RegGetValue(
        UIntPtr hkey, string lpSubKey, string lpValue, RegistryFlags dwFlags, 
        out RegistryType pdwType, IntPtr pvData, ref uint pcbData);
