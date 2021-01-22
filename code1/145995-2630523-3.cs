    public static IEnumerable<byte> streamAsIEnumerable(Stream stream)
    {
        if (stream != null)
            for (int i = stream.ReadByte(); i != -1; i = stream.ReadByte())
                yield return (byte)i;
    }
