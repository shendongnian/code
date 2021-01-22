    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class C {
    
      // first overload - varargs list is single int
      [DllImport("user32.dll", CallingConvention=CallingConvention.Cdecl)]
      static extern int wsprintf(
        [Out] StringBuilder buffer,
        string format,
        int arg);
    
      // second overload - varargs list is (int, string)
      [DllImport("user32.dll", CallingConvention=CallingConvention.Cdecl)]
      static extern int wsprintf(
        [Out] StringBuilder buffer,
        string format,
        int arg1,
        string arg2);
    
      public static void Main() {
        StringBuilder buffer = new StringBuilder();
        int result = wsprintf(buffer, "%d + %s", 42, "eggs!");
        Console.WriteLine("result: {0}\n{1}", result, buffer);
      }
    }
