    #if NET40
        public static void NET_Flush(FileStream mfs)
        {
            mfs.Flush(true);
        }
    #else
        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool FlushFileBuffers(IntPtr hFile);
        public static void NET_Flush(FileStream mfs)
        {
            mfs.Flush();
            IntPtr handle = mfs.SafeFileHandle.DangerousGetHandle();
            if (!FlushFileBuffers(handle))
                throw new System.ComponentModel.Win32Exception();
        }
    #endif
