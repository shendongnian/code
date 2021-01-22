    public static class ArrayCaster
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct Union
        {
            [FieldOffset(0)] public byte[] bytes;
            [FieldOffset(0)] public float[] floats;
        }
        private static readonly int byteId;
        private static readonly int floatId;
        static ArrayCaster()
        {
            byteId = getByteId();
            floatId = getFloatId();
        }
        public static void AsByteArray(this float[] floats, Action<byte[]> action)
        {
            if(floats == null)
            {
                action(null);
                return;
            }
            if(floats.Length == 0)
            {
                action(new byte[0]);
                return;
            }
            var union = new Union {floats = floats};
            union.bytes.fixArray(union.floats.Length * sizeof(float), byteId);
            try
            {
                action(union.bytes);
            }
            finally
            {
                union.bytes.fixArray(union.bytes.Length / sizeof(float), floatId);
            }
        }
        private static unsafe void fixArray(this byte[] bytes, int newSize, int newId)
        {
            fixed (byte* pBytes = bytes)
            {
                var pSize = (int*)(pBytes - 4);
                var pId = (int*)(pBytes - 8);
                *pSize = newSize;
                *pId = newId;
            }
        }
        private static unsafe int getByteId()
        {
            fixed (byte* pBytes = new byte[1])
            {
                return *(int*)(pBytes - 8);
            }
        }
        private static unsafe int getFloatId()
        {
            fixed (float* pFloats = new float[1])
            {
                var pBytes = (byte*) pFloats;
                return *(int*)(pBytes - 8);
            }
        }
    }
