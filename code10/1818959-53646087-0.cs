    public static Image ImageFromByteArray(byte[] bytes)
    {
        using (MemoryStream ms = new MemoryStream(bytes))
        using (Image image = Image.FromStream(ms, true, true))
        {
            return (Image)image.Clone();
        }
    }
