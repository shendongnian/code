    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct File_OP_Block 
    {
        public ushort fid;
        public ushort offset;
        public byte length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 240)]
        public string buff;
    }
