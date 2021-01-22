    public static class ImageFilesHelper
    {
        public static List<ImageFormat> ImageFormats =>
            typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public)
              .Select(p => (ImageFormat)p.GetValue(null, null)).ToList();
        public static ImageFormat ImageFormatFromRawFormat(ImageFormat raw) =>
            ImageFormats.FirstOrDefault(f => raw.Equals(f)) ?? ImageFormat.Bmp;
    }
    // usage:
    var format = ImageFilesHelper.ImageFormatFromRawFormat(Image.FromFile(myFile).RawFormat);
