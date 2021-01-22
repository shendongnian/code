    public static string GetFolderPath(SpecialFolder folder)
    {
        if (!Enum.IsDefined(typeof(SpecialFolder), folder))
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GetResourceString("Arg_EnumIllegalVal"), new object[] { (int) folder }));
        }
        StringBuilder lpszPath = new StringBuilder(260);
        Win32Native.SHGetFolderPath(IntPtr.Zero, (int) folder, IntPtr.Zero, 0, lpszPath);
        string path = lpszPath.ToString();
        new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
        return path;
    }
