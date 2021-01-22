    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class C {
    
      [DllImport("your.dll",
                 CallingConvention=CallingConvention.Cdecl,
                 CharSet=CharSet.Ansi)]
      static extern IntPtr complexFunction(
        string format,
        int arg1, int arg2);
      [DllImport("your.dll", CallingConvention=CallingConvention.Cdecl)]
      static extern void free(IntPtr p);
    
      public static void Main() {
        IntPtr pResult = complexFunction("%d > %s", 2, 1);
        string sResult = Marshal.PtrToStringAnsi(pResult);
        free(pResult);
        Console.WriteLine("result: {0}", sResult);
      }
    }
