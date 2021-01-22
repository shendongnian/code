        int[] data = { 1, 2, 3, 4, 5 };
        byte[] raw;
        using (var ms = new MemoryStream()) {
            Serializer.Serialize(ms, data);
            raw = ms.ToArray();
        }
        // read it back
        using (var ms = new MemoryStream(raw)) {
            data = Serializer.Deserialize<int[]>(ms);
        }
