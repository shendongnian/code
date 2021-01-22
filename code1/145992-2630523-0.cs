    public static IEnumerable<byte> streamAsIEnumerable(Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException("stream");
      
        for (;;)
        {
            byte readbyte = (byte)reader.ReadByte();
            if (readbyte == null)
                yield break;
            yield return readbyte;
        }
    }
