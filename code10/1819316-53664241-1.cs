    [StructLayout(LayoutKind.Explicit)]
    public struct CanChunk {
        [FieldOffset(0)] public UInt32 ReturnReadValue;
        [FieldOffset(4)] public UInt32 CanTime;
        [FieldOffset(8)] public UInt32 Can;
        [FieldOffset(12)] public UInt32 Ident;
        [FieldOffset(16)] public UInt32 DataLength;
        [FieldOffset(20)] public UInt64 Data;
        [FieldOffset(28)] public UInt32 Res;
        [FieldOffset(32)] public UInt64 TimeStamp;
    }
