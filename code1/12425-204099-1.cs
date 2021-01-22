    using System;
    using System.Runtime.InteropServices;
    
    class SystemChecker
    {
        static bool Is64Bit
        {
            get { return Marshal.SizeOf(typeof(IntPtr)) == 8; }
        }
    }
