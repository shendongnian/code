    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\tmp\test.txt";
            try
            {
                SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT();
    
                fileOp.wFunc = FO_Func.FO_COPY;
                fileOp.fFlags = (ushort)(FILEOP_FLAGS.FOF_RENAMEONCOLLISION);
    
                // file names need double-null termination
                fileOp.pFrom = file + '\0' + '\0';
                fileOp.pTo = file + '\0' + '\0';
                int hRes = SHFileOperation(ref fileOp);
                if (hRes != 0)
                {
                    throw new Win32Exception(hRes);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
    
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public FO_Func wFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTo;
            public ushort fFlags;
            public Int32 fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProgressTitle;
        }
    
        public enum FO_Func : uint
        {
            FO_MOVE = 0x0001,
            FO_COPY = 0x0002,
            FO_DELETE = 0x0003,
            FO_RENAME = 0x0004,
        }
    
        [Flags]
        public enum FILEOP_FLAGS : ushort
        {
            FOF_MULTIDESTFILES = 0x0001,
            FOF_CONFIRMMOUSE = 0x0002,
            FOF_SILENT = 0x0004,  
            FOF_RENAMEONCOLLISION = 0x0008,
            FOF_NOCONFIRMATION = 0x0010,  
            FOF_WANTMAPPINGHANDLE = 0x0020,  
            FOF_ALLOWUNDO = 0x0040,
            FOF_FILESONLY = 0x0080,  
            FOF_SIMPLEPROGRESS = 0x0100,  
            FOF_NOCONFIRMMKDIR = 0x0200,  
            FOF_NOERRORUI = 0x0400,  
            FOF_NOCOPYSECURITYATTRIBS = 0x0800,  
            FOF_NORECURSION = 0x1000,  
            FOF_NO_CONNECTED_ELEMENTS = 0x2000,  
            FOF_WANTNUKEWARNING = 0x4000,  
            FOF_NORECURSEREPARSE = 0x8000, 
        }
    }
