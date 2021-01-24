public static byte[] CompressImageStream(byte[] imageStream)
{
    using (var ms = new MemoryStream(imageStream))
    using (var original = new Bitmap(ms))
    using (var clonedWith32PixelsFormat = new Bitmap(
        original.Width,
        original.Height,
        PixelFormat.Format32bppPArgb))
    {
        using (Graphics gr = Graphics.FromImage(clonedWith32PixelsFormat))
        {
            gr.DrawImage(
                original,
                new Rectangle(0, 0, clonedWith32PixelsFormat.Width, clonedWith32PixelsFormat.Height));
        }
        using (Image compressedImage = new WuQuantizer().QuantizeImage(clonedWith32PixelsFormat))
        {
            return ImageToByteArray(compressedImage);
        }
    }
}
public static byte[] ImageToByteArray(Image image)
{
    if (image == null)
    {
        throw new ArgumentNullException(nameof(image));
    }
    using (var stream = new MemoryStream())
    {
        image.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }
}
