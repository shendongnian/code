    private struct DataType
    {
        public int X;
        public int Y;
    }
    private class NativeMethods
    {
        [DllImport("MyDll")]
        public static extern void SomeMethod(ref DataType value);
    }
