    static void Main(string[] args)
    {
        var data = new byte[] { 1, 8, 12, 15, 2, 0, 1 };
        // e.g. data.Max() + 1, but has to be known when loading the file
        var reasonableBase = 16;
        
        // converts the byte array into a large number of the known base (bypasses all the bit-mess)
        // the number will overflow if there is a lot of data, so use BigInteger to be safe
        // used int here for the sake of simplicity
        var serializedData = ByteArrayToNumberBased(data, reasonableBase);
        using (var target = File.OpenWrite("data.bin"))
        {
            using (var writer = new BinaryWriter(target))
            {
                writer.Write(serializedData); // 4 bytes instead of 14
            }
        }
        using (var target = File.OpenRead("data.bin"))
        {
            using (var reader = new BinaryReader(target))
            {
                int value = reader.ReadInt32();
                // chunk the bytes back of the big number we loaded
                // works because we know the base
                var deserializedData = NumberToByteArrayBased(serializedData, reasonableBase);
            }
        }
    }
    private static int ByteArrayToNumberBased(byte[] data, int numBase)
    {
        var result = 0;
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i] * (int)Math.Pow(numBase, i);
        }
        return result;
    }
    private static byte[] NumberToByteArrayBased(int data, int numBase)
    {
        var list = new List<Byte>();
        do
        {
            list.Add((byte)(data % numBase));
        }
        while ((data = (data / numBase)) > 0);
        return list.ToArray();
    }
