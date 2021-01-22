    [StructLayout(LayoutKind.Explicit)]
    struct StructType
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string FileDate;
        
        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string FileTime;
        
        [FieldOffset(16)]
        public int Id1;
        [FieldOffset(20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 66)] //Or however long Id2 is.
        public string Id2;
    }
