    public static class ImageExtentions
    {
        public static ImageCodecInfo GetCodecInfo(this Image img) =>
            ImageCodecInfo.GetImageDecoders().FirstOrDefault(decoder => decoder.FormatID == img.RawFormat.Guid);
        // Note: this will throw an exception if "file" is not an Image file
        // quick fix is a try/catch, but there are more sophisticated methods
        public static ImageCodecInfo GetCodecInfo(this string file)
        {
            using (var img = Image.FromFile(file))
                return img.GetCodecInfo();
        }
    }
    // Usage:
    string file = @"C:\MyImage.tif";
    string description = $"Image format is {file.GetCodecInfo()?.FormatDescription ?? "unknown"}.";
    Console.WriteLine(description);
