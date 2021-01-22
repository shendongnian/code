    using System;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit)]
    struct byte_array
    {
        [FieldOffset(0)]
        public byte byte1;
    
        [FieldOffset(1)]
        public byte byte2;
    
        [FieldOffset(2)]
        public byte byte3;
    
        [FieldOffset(3)]
        public byte byte4;
    
        [FieldOffset(0)]
        public short int1;
    
        [FieldOffset(2)]
        public short int2;
    }
