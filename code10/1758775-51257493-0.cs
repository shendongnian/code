    var byteArray = new byte[] { 0x00, 0x01, 0x02, 0x03 };
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
