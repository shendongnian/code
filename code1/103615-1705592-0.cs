    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PXUCAMR
    {
        [MarshalAs(UnmanagedType.I1)]
        public sbyte xumrversaocomc01;
        // null terminated string?
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string xumrcodfalhac05;
        // or just raw data?
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public sbyte[] xumrcodfalhac05;
    }
