    public static bool SaveImageFile(string fileName, ImageFormat format, Image img, 
                  Int64 quality)
    {
        ImageCodecInfo codec = GetEncoder(format);
        EncoderParameter qParam = new EncoderParameter(Encoder.Quality, quality);
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qParam;
        try
        {
            img.Save(fileName, codec, encoderParams);
            return true;
        }
        catch
        {
            return false;
        }
    }
    private static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        var codecs = ImageCodecInfo.GetImageDecoders();
        foreach (var codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
