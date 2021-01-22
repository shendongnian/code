    using System.Runtime.InteropServices;
    using System;
    
    class call_dll {
    
      [StructLayout(LayoutKind.Sequential, Pack=1)]
      private struct STRUCT_DLL {
        public Int32  count_int;
        public IntPtr ints;
      }
    
      [DllImport("mingw_dll.dll")]
      private static extern int func_dll(
          int an_int,
          [MarshalAs(UnmanagedType.LPArray)] byte[] string_filled_in_dll,
          ref STRUCT_DLL s
       );
      
      public static void Main() {
    
        byte[] string_filled_in_dll = new byte[21];
    
    
        STRUCT_DLL struct_dll = new STRUCT_DLL();
        struct_dll.count_int = 5;
        int[]  ia = new int[5];
        ia[0] = 2; ia[1] = 3; ia[2] = 5; ia[3] = 8; ia[4] = 13;
    
        GCHandle gch    = GCHandle.Alloc(ia);
        struct_dll.ints = Marshal.UnsafeAddrOfPinnedArrayElement(ia, 0);
    
        int ret=func_dll(5,string_filled_in_dll, ref struct_dll);
        
        Console.WriteLine("Return Value: " + ret);
        Console.WriteLine("String filled in DLL: " + System.Text.Encoding.ASCII.GetString(string_filled_in_dll));
    
      }
    }
