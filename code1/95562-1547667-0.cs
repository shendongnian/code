    public static Image CompressImage(string imagePath, long quality)
    {
        using(FileStream fs = File.OpenRead(imagePath)){
           Image srcImg = Image.FromStream(fs);    
        
           EncoderParameters parameters = new EncoderParameters(1);    
           parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);    
           ImageCodecInfo encoder = GetCodecInfo("image/jpeg");    
           srcImg.Save("d:\\creatives\\abcd123.jpg", encoder, parameters);
        }
    }
