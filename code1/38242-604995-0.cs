    class Program
    {
        static void Main(string[] args)
        {
            var mainStream = NativeMethods.CreateFileW(
                "testfile",
                NativeConstants.GENERIC_WRITE,
                NativeConstants.FILE_SHARE_WRITE,
                IntPtr.Zero,
                NativeConstants.OPEN_ALWAYS,
                0,
                IntPtr.Zero);
    
            var stream = NativeMethods.CreateFileW(
                "testfile:stream",
                NativeConstants.GENERIC_WRITE,
                NativeConstants.FILE_SHARE_WRITE,
                IntPtr.Zero,
                NativeConstants.OPEN_ALWAYS,
                0,
                IntPtr.Zero);
        }
    }
    
    public partial class NativeMethods
    {
    
        /// Return Type: HANDLE->void*
        ///lpFileName: LPCWSTR->WCHAR*
        ///dwDesiredAccess: DWORD->unsigned int
        ///dwShareMode: DWORD->unsigned int
        ///lpSecurityAttributes: LPSECURITY_ATTRIBUTES->_SECURITY_ATTRIBUTES*
        ///dwCreationDisposition: DWORD->unsigned int
        ///dwFlagsAndAttributes: DWORD->unsigned int
        ///hTemplateFile: HANDLE->void*
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "CreateFileW")]
        public static extern System.IntPtr CreateFileW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpFileName, uint dwDesiredAccess, uint dwShareMode, [System.Runtime.InteropServices.InAttribute()] System.IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, [System.Runtime.InteropServices.InAttribute()] System.IntPtr hTemplateFile);
    
    }
    
    
    public partial class NativeConstants
    {
    
        /// GENERIC_WRITE -> (0x40000000L)
        public const int GENERIC_WRITE = 1073741824;
    
        /// FILE_SHARE_DELETE -> 0x00000004
        public const int FILE_SHARE_DELETE = 4;
    
        /// FILE_SHARE_WRITE -> 0x00000002
        public const int FILE_SHARE_WRITE = 2;
    
        /// FILE_SHARE_READ -> 0x00000001
        public const int FILE_SHARE_READ = 1;
    
        /// OPEN_ALWAYS -> 4
        public const int OPEN_ALWAYS = 4;
    }
