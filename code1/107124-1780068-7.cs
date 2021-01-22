    public static Rectangle ReadRectangle32(this BinaryReader reader)
    {
        // Left (4 bytes)
        int left = reader.ReadInt32();
        // Top (4 bytes)
        int top = reader.ReadInt32();
        // Right (4 bytes)
        int right = reader.ReadInt32();
        // Bottom (4 bytes)
        int bottom = reader.ReadInt32();
        return Rectangle.FromLTRB(left, top, right, bottom);
    }
