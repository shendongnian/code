    static void Main(string[] args)
    {
        var data = new List<byte[]>() {
            new byte[] { 01, 05, 15, 04, 11, 00, 01, 01, 05, 15, 04, 11, 00, 01 },
            new byte[] { 09, 04, 02, 00, 08, 12, 01, 07, 04, 02, 00, 08, 12, 01 },
            new byte[] { 01, 05, 06, 04, 02, 00, 01, 01, 05, 06, 04, 02, 00, 01 }
        };
        // has to be known when loading the file
        var reasonableBase = data.SelectMany(i => i).Max() + 1;
        using (var target = File.OpenWrite("data.bin"))
        {
            using (var writer = new BinaryWriter(target))
            {
                // write the number of lines (16 bit, lines limited to 65536)
                writer.Write((ushort)data.Count);
                // write the base (8 bit, base limited to 255)
                writer.Write((byte)reasonableBase);
                foreach (var sample in data)
                {
                    // converts the byte array into a large number of the known base (bypasses all the bit-mess)
                    var serializedData = ByteArrayToNumberBased(sample, reasonableBase).ToByteArray();
                    // write the length of the sample (8 bit, limited to 255)
                    writer.Write((byte)serializedData.Length);
                    writer.Write(serializedData);
                }
            }
        }
        var deserializedData = new List<byte[]>();
        using (var source = File.OpenRead("data.bin"))
        {
            using (var reader = new BinaryReader(source))
            {
                var lines = reader.ReadUInt16();
                var sourceBase = reader.ReadByte();
                for (int i = 0; i < lines; i++)
                {
                    var length = reader.ReadByte();
                    var value = new BigInteger(reader.ReadBytes(length));
                    // chunk the bytes back of the big number we loaded
                    // works because we know the base
                    deserializedData.Add(NumberToByteArrayBased(value, sourceBase));
                }
            }
        }
    }
    private static BigInteger ByteArrayToNumberBased(byte[] data, int numBase)
    {
        var result = BigInteger.Zero;
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i] * BigInteger.Pow(numBase, i);
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
