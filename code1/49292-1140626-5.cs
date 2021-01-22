    using System;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    sealed class Device
    {
        public static IntPtr ActivateDevice(String lpszDevKey, IntPtr lpRegEnts, UInt32 cRegEnts, IntPtr lpvParam)
        {
            // this is a little wrapper around the p/invoke to 
            // ActivateDeviceEx which checks the error
            // and throws an exception, thus C#-ifying the Win32 API call.
            IntPtr hndDriver = ActivateDeviceEx(lpszDevKey, lpRegEnts, cRegEnts, lpvParam);
            if (IntPtr.Zero == hndDriver)
            {
                Int32 err = Marshal.GetLastWin32Error();
                throw new Win32Exception(err);
            }
            return hndDriver;
        }
        [DllImport("Coredll.dll", EntryPoint = "ActivateDeviceEx", 
            SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr ActivateDeviceEx(String lpszDevKey, 
            IntPtr lpRegEnts, UInt32 cRegEnts, IntPtr lpvParam);
        private Device() { }
    }
}
