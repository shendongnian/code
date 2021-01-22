    public static byte[] ReadFully(Stream input)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
