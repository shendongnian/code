    [StructLayout(LayoutKind.Explicit)]
    public struct ConvSByteBool
    {
        [FieldOffset(0)]
        public sbyte[] In;
        [FieldOffset(0)]
        public bool[] Out;
    }
