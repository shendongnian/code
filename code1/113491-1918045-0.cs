    [StructLayout(LayoutKind.Explicit)]
    public struct StringPair
    {
        [FieldOffset(0)] public String A;
        [FieldOffset(8)] public String B;
        [FieldOffset(16)] public String C;
        [FieldOffset(24)] public Date D;
        [FieldOffset(32)] public double V;
    }
