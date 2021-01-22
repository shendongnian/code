    public struct Smb_Parameters1
    {
        public byte WordCount; //1 byte
        public ushort[] Words; //4 bytes (a "pointer")
    }
    Marshal.SizeOf(typeof(Smb_Parameters1)); //8 (with padding)
    //I don't see how you get 4 unless you are on a 16-bit system maybe
    [StructLayout(LayoutKind.Sequential)]
    public struct Smb_Parameters2
    {
        public byte WordCount; //1 byte
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        public ushort[] Words; //20 bytes (2 * 10 bytes)
    }
    Marshal.SizeOf(typeof(Smb_Parameters2)); //22 (with padding)
