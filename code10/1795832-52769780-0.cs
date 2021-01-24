    public static Int32 GetHighestValue(Byte[] bytes)
    {
        Int32 maxval = 0;
        try
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            using (BinaryReader reader = new BinaryReader(ms))
            {
                while (true)
                {
                    // Clear highest bit so the value's always a positive Int32.
                    Int32 val = (Int32)(reader.ReadUInt32() & 0x7FFFFFFF);
                    if (val > maxval)
                        maxval = val;
                }
            }
        }
        catch (EndOfStreamException ex)
        {
            // Finished reading!
        }
        return maxval;
    }
