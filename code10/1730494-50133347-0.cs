    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LaserPoint {
        public UInt16 x;                   // 2 bytes
        public UInt16 y;                   // 2 bytes
        [MarhalAs(UnmanagedType.ByValArray, SizeConst = 6]
        public byte[] colors;              // 6 bytes
    }
