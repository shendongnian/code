    [StructLayout(LayoutKind.Sequential)]
    public struct ExportedSymbols
    {
      public NativeMethods.DisposeStablePointer FuncPointerDispose;
      public NativeMethods.DisposeString FuncStringDispose;
      public NativeMethods.IsInstance FuncIsInstance;
      public NativeMethods.Foo FuncFoo;
    }
