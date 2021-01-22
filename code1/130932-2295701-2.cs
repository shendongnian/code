    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public uint wFunc;
        public string pFrom;
        public string pTo;
        public ushort fFlags;
        public int fAnyOperationsAborted;
        public IntPtr hNameMappings;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszProgressTitle; 
    }
    
    private const int FO_DELETE = 0x0003;
    private const int FOF_SILENT = 0x0004;
    private const int FOF_ALLOWUNDO = 0x0040;
    private const int FOF_NOCONFIRMATION = 0x0010;
    private const int FOF_WANTNUKEWARNING = 0x4000;
    
    [DllImport("Shell32.dll")]
    static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);
