    using System;
    using System.IO;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            IntPtr hdl = CreateFile("\\\\.\\ADVSYS", FileAccess.ReadWrite,
                FileShare.None, IntPtr.Zero, FileMode.Open,
                FileOptions.None, IntPtr.Zero);
            if (hdl == (IntPtr)(-1)) throw new Win32Exception();
            try {
                byte drawer = 1;
                bool ok = DeviceIoControl(hdl, CTLCODE, ref drawer, 1, IntPtr.Zero,
                    0, IntPtr.Zero, IntPtr.Zero);
                if (!ok) throw new Win32Exception();
            }
            finally {
                CloseHandle(hdl);
            }
        }
        // P/Invoke:
        private const uint CTLCODE = 0xdaf52480;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFile(string filename, FileAccess access,
              FileShare sharing, IntPtr SecurityAttributes, FileMode mode,
              FileOptions options, IntPtr template
        );
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool DeviceIoControl(IntPtr device, uint ctlcode,
            ref byte inbuffer, int inbuffersize,
            IntPtr outbuffer, int outbufferSize,
            IntPtr bytesreturned, IntPtr overlapped
        );
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hdl);
    }
