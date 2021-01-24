    public void Save(Stream stream, ImageFormat format)
    {
        if (format == null)
        {
            throw new ArgumentNullException("format");
        }
        ImageCodecInfo encoder = format.FindEncoder();
        this.Save(stream, encoder, null);
    }
