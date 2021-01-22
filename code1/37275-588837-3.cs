    using System;
    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Sequential)]
    class Blittable
    {
        int x;
    }
    class Program
    {
        public static unsafe void Main()
        {
            int i;
            object o = new Blittable();
            int* ptr = &i;
            IntPtr addr = (IntPtr)ptr;
            Console.WriteLine(addr.ToString("x"));
            GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
            addr = h.AddrOfPinnedObject();
            Console.WriteLine(addr.ToString("x"));
            h.Free();
        }
    }
