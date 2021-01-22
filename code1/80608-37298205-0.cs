    [StructLayout(LayoutKind.Sequential)]
    public struct BY_HANDLE_FILE_INFORMATION
    {
        public uint FileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
        public uint VolumeSerialNumber;
        public uint FileSizeHigh;
        public uint FileSizeLow;
        public uint NumberOfLinks;
        public uint FileIndexHigh;
        public uint FileIndexLow;
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetFileInformationByHandle(
            IntPtr hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
    public ulong GetFileIndex(FileStream fs) 
    {
        BY_HANDLE_FILE_INFORMATION info;
        GetFileInformationByHandle(fs.SafeFileHandle.DangerousGetHandle(), out info);
        return ((ulong)info.FileIndexHigh << 32) + (ulong) info.FileIndexLow;
    }
