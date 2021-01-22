    [StructLayout(LayoutKind.Explicit)]
    public class A
    {
        [FieldOffset(0)]
        public byte One;
        [FieldOffset(1)]
        public byte Two;
        [FieldOffset(2)]
        public byte Three;
        [FieldOffset(3)]
        public byte Four;
        [FieldOffset(0)]
        public int Int32;
    }
