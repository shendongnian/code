    using System;
    using System.Runtime.InteropServices;
    
    class Program {
      unsafe static void Main(string[] args) {
        int len = Marshal.SizeOf(typeof(Test));
        IntPtr mem = Marshal.AllocCoTaskMem(len);
        Test* ptr = (Test*)mem;
        ptr->member1 = 42;
        // call method
        //..
        int value = ptr->member1;
        Marshal.FreeCoTaskMem(mem);
      }
      public struct Test {
        public int member1;
      }
    }
