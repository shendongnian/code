    Thread workerThread = new Thread(new ThreadStart((MethodInvoker)(()=>
    {    
         foreach(var file in GetFilesUnmanaged(@"C:\myDir", "*.txt"))
              File.Delete(file);
    })));
    workerThread.Start();
    //just go on with your normal requests, the directory will be cleaned while the user can just surf around
---
       public static IEnumerable<string> GetFilesUnmanaged(string directory, string filter)
            {
                return new FilesFinder(Path.Combine(directory, filter))
    				.Where(f => (f.Attributes & FileAttributes.Normal) == FileAttributes.Normal
    					|| (f.Attributes & FileAttributes.Archive) == FileAttributes.Archive)
                    .Select(s => s.FileName);
            }
        }
    public class FilesEnumerator : IEnumerator<FoundFileData>
    {
        #region Interop imports
        private const int ERROR_FILE_NOT_FOUND = 2;
        private const int ERROR_NO_MORE_FILES = 18;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool FindNextFile(SafeHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);
        #endregion
        #region Data Members
        private readonly string _fileName;
        private SafeHandle _findHandle;
        private WIN32_FIND_DATA _win32FindData;
        #endregion
        public FilesEnumerator(string fileName)
        {
            _fileName = fileName;
            _findHandle = null;
            _win32FindData = new WIN32_FIND_DATA();
        }
        #region IEnumerator<FoundFileData> Members
        public FoundFileData Current
        {
            get
            {
                if (_findHandle == null)
                    throw new InvalidOperationException("MoveNext() must be called first");
                return new FoundFileData(ref _win32FindData);
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (_findHandle == null)
            {
                _findHandle = new SafeFileHandle(FindFirstFile(_fileName, out _win32FindData), true);
                if (_findHandle.IsInvalid)
                {
                    int lastError = Marshal.GetLastWin32Error();
                    if (lastError == ERROR_FILE_NOT_FOUND)
                        return false;
                    throw new Win32Exception(lastError);
                }
            }
            else
            {
                if (!FindNextFile(_findHandle, out _win32FindData))
                {
                    int lastError = Marshal.GetLastWin32Error();
                    if (lastError == ERROR_NO_MORE_FILES)
                        return false;
                    throw new Win32Exception(lastError);
                }
            }
            return true;
        }
        public void Reset()
        {
            if (_findHandle.IsInvalid)
                return;
            _findHandle.Close();
            _findHandle.SetHandleAsInvalid();
        }
        public void Dispose()
        {
            _findHandle.Dispose();
        }
        #endregion
    }
    public class FilesFinder : IEnumerable<FoundFileData>
    {
        readonly string _fileName;
        public FilesFinder(string fileName)
        {
            _fileName = fileName;
        }
        public IEnumerator<FoundFileData> GetEnumerator()
        {
            return new FilesEnumerator(_fileName);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class FoundFileData
    {
        public string AlternateFileName;
        public FileAttributes Attributes;
        public DateTime CreationTime;
        public string FileName;
        public DateTime LastAccessTime;
        public DateTime LastWriteTime;
        public UInt64 Size;
        internal FoundFileData(ref WIN32_FIND_DATA win32FindData)
        {
            Attributes = (FileAttributes)win32FindData.dwFileAttributes;
            CreationTime = DateTime.FromFileTime((long)
                    (((UInt64)win32FindData.ftCreationTime.dwHighDateTime << 32) +
                     (UInt64)win32FindData.ftCreationTime.dwLowDateTime));
            LastAccessTime = DateTime.FromFileTime((long)
                    (((UInt64)win32FindData.ftLastAccessTime.dwHighDateTime << 32) +
                     (UInt64)win32FindData.ftLastAccessTime.dwLowDateTime));
            LastWriteTime = DateTime.FromFileTime((long)
                    (((UInt64)win32FindData.ftLastWriteTime.dwHighDateTime << 32) +
                     (UInt64)win32FindData.ftLastWriteTime.dwLowDateTime));
            Size = ((UInt64)win32FindData.nFileSizeHigh << 32) + win32FindData.nFileSizeLow;
            FileName = win32FindData.cFileName;
            AlternateFileName = win32FindData.cAlternateFileName;
        }
    }
    /// <summary>
    /// Safely wraps handles that need to be closed via FindClose() WIN32 method (obtained by FindFirstFile())
    /// </summary>
    public class SafeFindFileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(SafeHandle hFindFile);
        public SafeFindFileHandle(bool ownsHandle)
            : base(ownsHandle)
        {
        }
        protected override bool ReleaseHandle()
        {
            return FindClose(this);
        }
    }
    // The CharSet must match the CharSet of the corresponding PInvoke signature
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATA
    {
        public uint dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    }
