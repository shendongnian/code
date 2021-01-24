    public static Bitmap ByteArrayToImage(byte[] source)
    {
        Bitmap bmp;
        using (var ms = new MemoryStream(source))
        {
            bmp = new Bitmap(ms);
        }
        return bmp;
    }
