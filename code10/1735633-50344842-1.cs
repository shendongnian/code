    static void Main(string[] args)
    {
        var data = new byte[] { 1, 5, 6, 4, 2, 0, 1 };
        // e.g. data.Max() + 1, but has to be known when loading the file
        var reasonableBase = 7;
        // converts the byte array into a large number of the known base (bypasses all the bit-mess)
        var serializedData = ByteArrayToNumberBased(data, reasonableBase);
        using (var target = File.OpenWrite("data.bin"))
        {
            using (var writer = new BinaryWriter(target))
            {
                writer.Write(serializedData.ToByteArray()); // 3 bytes instead of 14 (78% less data)
            }
        }
        var value = new BigInteger(File.ReadAllBytes("data.bin"));
        // chunk the bytes back of the big number we loaded
        // works because we know the base
        var deserializedData = NumberToByteArrayBased(serializedData, reasonableBase);
    }
    private static BigInteger ByteArrayToNumberBased(byte[] data, int numBase)
    {
        var result = BigInteger.Zero;
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i] * (int)Math.Pow(numBase, i);
        }
        return result;
    }
    private static byte[] NumberToByteArrayBased(BigInteger data, int numBase)
    {
        var list = new List<Byte>();
        do
        {
            list.Add((byte)(data % numBase));
        }
        while ((data = (data / numBase)) > 0);
        return list.ToArray();
    }
