    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct Mapping
    {
        public byte nAlternate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=260)]
        public char[] Name;
        public uint NbSectors;
        public IntPtr pSectors;
    }
