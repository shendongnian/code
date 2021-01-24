    public static byte[] CreateImageThumbnail(byte[] image, int width, int height)
    {
        using (var stream = new System.IO.MemoryStream(image))
        {
            var img = Image.FromStream(stream);
            var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
            using (var thumbStream = new System.IO.MemoryStream())
            {
                thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return thumbStream.ToArray();
            }
        }
    }
