        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);
        public static ulong GetDiskFreeSpace(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            ulong dummy = 0;
            if (!GetDiskFreeSpaceEx(path, out ulong freeSpace, out dummy, out dummy))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return freeSpace;
        }
