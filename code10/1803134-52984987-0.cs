    [StructLayout(LayoutKind.Explicit)]
    public struct ODBDGN_CODE
    {
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AXIS)]
        public byte[] cdatas;
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AXIS)]
        public short[] idatas;
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AXIS)]
        public int[] ldatas;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class ODBDGN
    {
        public short datano;    
        public short type;      
        public ODBDGN_CODE code;
    }
