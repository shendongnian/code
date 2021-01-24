    using System.Runtime.InteropServices;
    class Main
    {
        [DllImport(DLL_FILE, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Read(out IntPtr buffer);
        [DllImport(DLL_FILE, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Write(byte[] buffer);
        public static void ReadFromExtern()
        {
            IntPtr bufferPtr = IntPtr.Zero;
            Read(bufferPtr);
        
            int length = LENGTH;
            byte[] buffer = new byte[length];        
            Marshal.Copy(bufferPtr, buffer, 0, length);
            //do something with buffer
        }
        public static void WriteToExtern(byte[] buffer)
        {
            Write(buffer);
            //or do something else
        }
    }
