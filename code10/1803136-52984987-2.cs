    [StructLayout(LayoutKind.Sequential)]
    public class ODBDGN
    {
        public short datano;    
        public short type;      
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AXIS)]
        public byte[] code;
    }
