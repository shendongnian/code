    using System;
    using System.IO;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.InteropServices;
    class Comm : IDisposable
    {
        [DllImport("MSVCRT.DLL", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr _get_osfhandle(int fd);
     
        public readonly Stream Stream;
     
        public Comm(int fd)
        {
            var handle = _get_osfhandle(fd);
            if (handle == IntPtr.Zero || handle == (IntPtr)(-1) || handle == (IntPtr)(-2))
            {
                throw new ApplicationException("invalid handle");
            }
    
            var fileHandle = new SafeFileHandle(handle, true);
            Stream = new FileStream(fileHandle, FileAccess.ReadWrite);
        }
     
        public void Dispose()
        {
            Stream.Dispose();
        }       
    }
