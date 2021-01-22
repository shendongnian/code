    [StructLayout(LayoutKind.Explicit)]
    public struct Message
    {
        [FieldOffset(0)]
        public int a;
        [FieldOffset(4)]
        public short b;
        [FieldOffset(6)]
        public int c;
        [FieldOffset(22)] //Leave some empty space just for the heck of it.
        public DateTime dt;
    }
