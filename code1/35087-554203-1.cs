    public byte[] BufferFromImage(BitmapImage imageSource)
    {        
        Stream stream = imageSource.StreamSource;
        byte[] buffer = null;
        if (stream != null && stream.Length > 0)
        {
            using (BinaryReader br = new BinaryReader(stream))
            {
                buffer = br.ReadBytes((Int32)stream.Length);
            }
        }
        return buffer;
    }
