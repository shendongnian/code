    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    public static class ImageExtentions
    {
        public static ImageCodecInfo GetCodecInfo(this System.Drawing.Image img)
        {
            ImageCodecInfo[] decoders = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo decoder in decoders)
                if (img.RawFormat.Guid == decoder.FormatID)
                    return decoder;
            return null;
        }
    }
