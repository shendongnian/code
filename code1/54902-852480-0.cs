        [StructLayout(LayoutKind.Explicit, Pack=1)]
        public struct ByteArrayUnion
        {
            #region Byte Fields union
            [FieldOffset(0)]
            public byte Byte1;
            [FieldOffset(1)]
            public byte Byte2;
            [FieldOffset(2)]
            public byte Byte3;
            [FieldOffset(3)]
            public byte Byte4;
            #endregion
            #region Int Field union
            [FieldOffset(0)]
            public int Int1;
            [FieldOffset(4)]
            public int Int2;
            #endregion
        }
