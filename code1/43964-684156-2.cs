    private static void SaveCompressed(this Image img, string fileName, 
            long quality) {
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
        img.Save(fileName, GetCodecInfo("image/jpeg"), parameters);
    }
