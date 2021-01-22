        // note I've used arrays in the example; lists are identical
        int[] data = { 1, 2, 3, 4, 5 };
        byte[] raw;
        using (var ms = new MemoryStream())
        using (var writer = new BinaryWriter(ms))
        {
            writer.Write(data.Length);
            foreach(int i in data) {
                writer.Write(i);
            }
            writer.Close();
            raw = ms.ToArray();
        }
        // read it back
        using (var ms = new MemoryStream(raw))
        using (var reader = new BinaryReader(ms))
        {
            int count = reader.ReadInt32();
            data = new int[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = reader.ReadInt32();
            }
        }
