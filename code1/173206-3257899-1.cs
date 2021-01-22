    public static byte[] IconToBytes(Icon icon)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            icon.Save(ms);
            return ms.ToArray();
        }
    }
    public static Icon BytesToIcon(byte[] bytes)
    {
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            return new Icon(ms);
        }
    }
