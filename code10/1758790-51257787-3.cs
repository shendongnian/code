    public static int[] GetIntsJohn(byte[] byteArray)
    {
        int[] result = new int[byteArray.Length / 4];
        for (int i = 0; i < result.Length; ++i)
        {
            var srcBytes = byteArray.Skip(i * 4).Take(4);
            if (BitConverter.IsLittleEndian)
            {
                srcBytes = srcBytes.Reverse();
            }
            result[i] = BitConverter.ToInt32(srcBytes.ToArray(), 0);
        }
        return result;
    }
    public static uint SwapBytes(uint x)
    {
        // swap adjacent 16-bit blocks
        x = (x >> 16) | (x << 16);
        // swap adjacent 8-bit blocks
        return ((x & 0xFF00FF00) >> 8) | ((x & 0x00FF00FF) << 8);
    }
    public static int[] GetIntsGeneral(byte[] source)
    {
        var result = new int[source.Length / 4];
        Buffer.BlockCopy(source, 0, result, 0, source.Length);
        return result.Select(x => (int)SwapBytes((uint)x)).ToArray();
    }
