    public static FileInfo SaveAsJpeg(string newFilePath, long quality)
    {
        var path = @"C:\Temp\test.tif";
        using (var stream = new MemoryStream(File.ReadAllBytes(path)))
        {
            var imageToConvert = Image.FromStream(stream); 
            using (imageToConvert = new Bitmap(imageToConvert))
            {
                imageToConvert.Save(newFilePath, GetDecoder(ImageFormat.Jpeg), GetQualityEncoderParameters(quality));
            }
        }
        return new FileInfo(newFilePath);
    }
