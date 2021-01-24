    [StructLayout(LayoutKind.Sequential)]
    public struct myStructure
    {
        public Fn1 Func1;
        public Fn2 Func2;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Fn1(IntPtr p1, ref int p2);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Fn2(IntPtr p1, ref int p2);
    }
    [DllImport("lib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void functionInterface(out myStructure pToStruct);
