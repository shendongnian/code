    static public class FileOSInfo
    {
        struct BY_HANDLE_FILE_INFORMATION
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
    
        //
        // CreateFile constants
        //
        const uint FILE_SHARE_READ = 0x00000001;
        const uint OPEN_EXISTING = 3;
        const uint GENERIC_READ = (0x80000000);
        const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
    
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetFileInformationByHandle(IntPtr hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
    
        static public bool CompareFiles(string path1, string path2)
        {
            BY_HANDLE_FILE_INFORMATION fileInfo1, fileInfo2;
            IntPtr ptr1 = CreateFile(path1, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);
            if ((int)ptr1 == -1)
            {
                System.ComponentModel.Win32Exception e = new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                throw e;
            }
            IntPtr ptr2 = CreateFile(path2, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);
            if ((int)ptr2 == -1)
            {
                System.ComponentModel.Win32Exception e = new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                throw e;
            }
            GetFileInformationByHandle(ptr1, out fileInfo1);
            GetFileInformationByHandle(ptr2, out fileInfo2);
    
            return ((fileInfo1.FileIndexHigh == fileInfo2.FileIndexHigh) &&
                (fileInfo1.FileIndexLow == fileInfo2.FileIndexLow));
        }
    }
