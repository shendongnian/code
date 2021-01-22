    [StructLayout(LayoutKind.Explicit)] 
    public struct SampleUnion
    {
        [FieldOffset(0)] public single bar;
        [FieldOffset(4)] public int killroy;
        [FieldOffset(4)] public float fubar;
    }
