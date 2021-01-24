    public class NativeMethods
    {
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate void DisposeStablePointer(IntPtr ptr);
    
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate void DisposeString([MarshalAs(UnmanagedType.LPStr)] string str);
    
      // this assumes that bar_KBoolean is defined as an int
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      [return: MarshalAs(UnmanagedType.Bool)]
      public delegate bool IsInstance(IntPtr pRef, IntPtr type);
    
      [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
      public delegate void Foo([MarshalAs(UnmanagedType.LPStr)] string str);
    
      [DllImport("KONAN_bar.dll", EntryPoint = "bar_symbols")]
      public static extern IntPtr BarSymbols();
    }
