    public static long ReadVlqInt64(this BinaryReader r)
    {
        byte b = r.ReadByte();
        // the first byte has 6 bits of the raw value
        int shift = 6;
        ulong raw = (ulong)(b & 0x3F);
        bool negative = (b & 0x80) != 0;
        // first continue flag is the second bit from the top, shift it into the sign
        bool cont = (b & 0x40) != 0;
        if (cont)
        {
            while (true)
            {
                b = r.ReadByte();
                cont = (b & 0x80) != 0;
                b &= 0x7F;
                if (shift == 62)
                {
                    if (negative)
                    {
                        // minumum value abs(long.MinValue)
                        if (b > 0x2 || (b == 0x2 && raw != 0))
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        // maximum value long.MaxValue
                        if (b > 0x1)
                        {
                            throw new Exception();
                        }
                    }
                }
                // these bytes have 7 bits of the raw value
                raw |= ((ulong)b) << shift;
                if (!cont)
                {
                    break;
                }
                if (shift == 62)
                {
                    throw new Exception();
                }
                shift += 7;
            }
        }
        if (!negative)
        {
            return (long)raw;
        }
        if (raw == (ulong)long.MaxValue + 1)
        {
            return long.MinValue;
        }
        return -(long)raw;
    }
    public static void WriteVlqInt64(this BinaryWriter r, long n)
    {
        bool negative = n < 0;
        // Special handling for long.MinValue
        ulong raw = negative ? n == long.MinValue ? (ulong)long.MaxValue + 1 : (ulong)-n : (ulong)n;
        byte b = (byte)(raw & 0x3F);
        if (negative)
        {
            b |= 0x80;
        }
        raw >>= 6;
        bool cont = raw != 0;
        if (cont)
        {
            b |= 0x40;
        }
        r.Write(b);
        while (cont)
        {
            b = (byte)(raw & 0x7F);
            raw >>= 7;
            cont = raw != 0;
            if (cont)
            {
                b |= 0x80;
            }
            r.Write(b);
        }
    }
    public static int ReadVlqInt32(this BinaryReader r)
    {
        byte b = r.ReadByte();
        // the first byte has 6 bits of the raw value
        int shift = 6;
        uint raw = (uint)(b & 0x3F);
        bool negative = (b & 0x80) != 0;
        // first continue flag is the second bit from the top, shift it into the sign
        bool cont = (b & 0x40) != 0;
        if (cont)
        {
            while (true)
            {
                b = r.ReadByte();
                cont = (b & 0x80) != 0;
                b &= 0x7F;
                if (shift == 27)
                {
                    if (negative)
                    {
                        // minumum value abs(int.MinValue)
                        if (b > 0x10 || (b == 0x10 && raw != 0))
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        // maximum value int.MaxValue
                        if (b > 0xF)
                        {
                            throw new Exception();
                        }
                    }
                }
                // these bytes have 7 bits of the raw value
                raw |= ((uint)b) << shift;
                if (!cont)
                {
                    break;
                }
                if (shift == 27)
                {
                    throw new Exception();
                }
                shift += 7;
            }
        }
        if (!negative)
        {
            return (int)raw;
        }
        if (raw == (uint)int.MaxValue + 1)
        {
            return int.MinValue;
        }
        return -(int)raw;
    }
    public static void WriteVlqInt32(this BinaryWriter r, int n)
    {
        bool negative = n < 0;
        // Special handling for int.MinValue
        uint raw = negative ? n == int.MinValue ? (uint)int.MaxValue + 1 : (uint)-n : (uint)n;
        byte b = (byte)(raw & 0x3F);
        if (negative)
        {
            b |= 0x80;
        }
        raw >>= 6;
        bool cont = raw != 0;
        if (cont)
        {
            b |= 0x40;
        }
        r.Write(b);
        while (cont)
        {
            b = (byte)(raw & 0x7F);
            raw >>= 7;
            cont = raw != 0;
            if (cont)
            {
                b |= 0x80;
            }
            r.Write(b);
        }
    }
