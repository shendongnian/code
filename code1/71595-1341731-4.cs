    [StructLayout(LayoutKind.Explicit, Size=8)]
    public struct SomeStruct
    {
       [FieldOffset(0)]
       public byte SomeByte;
       [FieldOffset(1)]
       public int SomeInt;
       [FieldOffset(5)]
       public short SomeShort;
       [FieldOffset(7)]
       public byte SomeByte2;
    }
