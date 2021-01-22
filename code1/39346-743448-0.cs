        [StructLayout(LayoutKind.Explicit)]
        struct ArrayConvert
        {
            public static byte[] GetBytes(float[] floats)
            {
                ArrayConvert ar = new ArrayConvert();
                ar.floats = floats;
                ar.length.val = floats.Length * 4;
                return ar.bytes;
            }
            public static float[] GetFloats(byte[] bytes)
            {
                ArrayConvert ar = new ArrayConvert();
                ar.bytes = bytes;
                ar.length.val = bytes.Length / 4;
                return ar.floats;
            }
            public static byte[] GetTop4BytesFrom(object obj)
            {
                ArrayConvert ar = new ArrayConvert();
                ar.obj = obj;
                return new byte[]
                {
                    ar.top4bytes.b0,
                    ar.top4bytes.b1,
                    ar.top4bytes.b2,
                    ar.top4bytes.b3
                };
            }
            public static byte[] GetBytesFrom(object obj, int size)
            {
                ArrayConvert ar = new ArrayConvert();
                ar.obj = obj;
                ar.length.val = size;
                return ar.bytes;
            }
            class ArrayLength
            {
                public int val;
            }
            class Top4Bytes
            {
                public byte b0;
                public byte b1;
                public byte b2;
                public byte b3;
            }
            
            [FieldOffset(0)]
            private Byte[] bytes;
            [FieldOffset(0)]
            private object obj;
            [FieldOffset(0)]
            private float[] floats;
            [FieldOffset(0)]
            private ArrayLength length;
            [FieldOffset(0)]
            private Top4Bytes top4bytes;
        }
