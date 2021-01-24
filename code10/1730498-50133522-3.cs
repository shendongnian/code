    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct LaserPoint {
        public UInt16 x;                  
        public UInt16 y;                     	 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] colors;             
    }
