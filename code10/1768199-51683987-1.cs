    [[DllImport("mylib", CallingConvention = CallingConvention.Cdecl)]
    [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef= typeof(typeMarshaler))]
    private static extern type Foo();
    private class typeMarshaler : ICustomMarshaler
    {
        public static readonly typeMarshaler Instance = new typeMarshaler();
        public static ICustomMarshaler GetInstance(string cookie) => Instance;
        public int GetNativeDataSize() => -1;
        public object MarshalNativeToManaged(IntPtr nativeData) => Marshal.PtrToStructure<type>(nativeData);
        // in this sample I suppose the native side uses GlobalAlloc (or LocalAlloc)
        // but you can use any allocation library provided you use the same on both sides
        public void CleanUpNativeData(IntPtr nativeData) => Marshal.FreeHGlobal(nativeData);
        public IntPtr MarshalManagedToNative(object managedObj) => throw new NotImplementedException();
        public void CleanUpManagedData(object managedObj) => throw new NotImplementedException();
    }
    [StructLayout(LayoutKind.Sequential)]
    class type
    {
        /* declare fields */
    };
