    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct DATASTRUCT
    {
        public int x;
        public int y;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string s;
        public double d;
        public char c;
    };
