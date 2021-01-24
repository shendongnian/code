    public static Bitmap ByteArrayToImage(byte[] source)
    {
        using (var ms = new MemoryStream(source))
        {
            return new Bitmap(ms);
        }
       
    }
