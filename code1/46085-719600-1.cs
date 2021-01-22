    public byte[] ToByteArray(this bool[] bits)
    {
        var bytes = new byte[bits.Length / 8];
        for (int i = 0, j = 0; j < bits.Length; i++, j += 8)
        {
            // Create byte from bits where LSB is read first.
            for (int offset = 0; offset < 8; offset++)
                bytes[i] |= (bits[j + offset] << offset);
        }
        return bytes;
    }
