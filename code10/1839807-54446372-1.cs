    public void Save(Stream stream, ImageCodecInfo encoder, EncoderParameters encoderParams)
    {
        if (stream == null)
        {
            throw new ArgumentNullException("stream");
        }
        if (encoder == null)
        {
            throw new ArgumentNullException("encoder");
        }
