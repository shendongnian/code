    public static Point ReadPoint16(this BinaryReader reader)
    {
        // x (2 bytes)
        int x = reader.ReadUInt16();
        // y (2 bytes)
        int y = reader.ReadUInt16();
        return new Point(x, y);
    }
