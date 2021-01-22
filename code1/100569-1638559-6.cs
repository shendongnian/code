    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public unsafe struct DataStruct
    {
        public int x;
        public int y;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string s;
        public double d;
        public char c;
    };
