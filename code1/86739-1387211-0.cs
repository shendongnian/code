    EncoderParameter epQuality = new EncoderParameter(
        System.Drawing.Imaging.Encoder.Quality,
        (int)numQual.Value);
    ...
    newImage.Save(..., iciJpegCodec, epParameters);
