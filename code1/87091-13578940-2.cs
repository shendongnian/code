    // Pinvoke for API function
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
    out ulong lpFreeBytesAvailable,
    out ulong lpTotalNumberOfBytes,
    out ulong lpTotalNumberOfFreeBytes);
    public static bool DriveFreeBytes(string folderName, out ulong freespace)
    {
        freespace = 0;
        if (string.IsNullOrEmpty(folderName))
        {
            throw new ArgumentNullException("folderName");
        }
        if (!folderName.EndsWith("\\"))
        {
            folderName += '\\';
        }
        ulong free = 0, dummy1 = 0, dummy2 = 0;
        if (GetDiskFreeSpaceEx(folderName, out free, out dummy1, out dummy2))
        {
            freespace = free;
            return true;
        }
        else
        {
            return false;
        }
    }
