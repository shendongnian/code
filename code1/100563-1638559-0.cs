    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public unsafe struct PvData
    {
        public int DistrictNumber;
        public int CountyNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=40)]
        public string Road;
        public double MilePoint;
        public char Direction;
    };
