    [StructLayout(LayoutKind.Sequential)]
    public struct Mapping
    {
        public byte nAlternate;
        [MarshalAs(UnmanagedType.LPStr, SizeConst=260)]
        public StringBuilder Name;
        public uint NbSectors;
        public IntPtr pSectors;
        public Mapping()
        {
            Name = new StringBuilder(259); 
            //This will be a buffer of size 260 (259 chars + '\0')
        }
    }
