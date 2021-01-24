    [StructLayout(LayoutKind.Explicit)]
    public struct ConvSByteBool
    {
        [FieldOffset(0)]
        public sbyte[] Array1;
        [FieldOffset(0)]
        public bool[] Array2;
    }
