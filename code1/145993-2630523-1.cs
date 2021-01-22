    public static IEnumerable<byte> streamAsIEnumerable(Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException("stream");
        for (; ; )
        {
            int readbyte = stream.ReadByte();
            if (readbyte == -1)
                yield break;
            yield return (byte)readbyte;
        }
    }
