    class UnMangedWrapper 
    {
        [DllImport("NativeCore.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetNodeName(IntPtr ptr);
    }
