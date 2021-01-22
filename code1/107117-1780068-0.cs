    byte[] buffer;
    using (var stream = new MemoryStream(buffer))
    using (var reader = new BinaryReader(stream))
    {
        int count = reader.ReadUInt16();
        int[] lengths = new int[count];
        for (int i = 0; i < lengths.Length; i++)
        {
            lengths[i] = reader.ReadUInt16();
        }
        Point[][] points = new Point[count][];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Point[lengths[i]];
            for (int j = 0; j < points[i].Length; j++)
            {
                int x = reader.ReadUInt16();
                int y = reader.ReadUInt16();
                points[i][j] = new Point(x, y);
            }
        }
    }
