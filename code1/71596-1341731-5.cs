    [StructLayout(LayoutKind.Explicit, Size=8)]
    public struct SomeStruct
    {
       [FieldOffset(0)]
       public byte SomeByte;
       [FieldOffset(1)]
       public byte SomeByte2;
       [FieldOffset(2)]
       public short SomeShort;
       [FieldOffset(4)]
       public int SomeInt;
    }
