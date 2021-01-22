    using (Image original = Image.FromStream(new MemoryStream(blogPhoto)))
    {
        using (MemoryStream thumbData = new MemoryStream())
        {
            int newWidth;
            int newHeight;
            if ((original.Width <= newMaxWidth) || 
                (original.Height <= newMaxHeight))
            {
                original.Save(thumbData, ImageFormat.Jpeg);
                return thumbData.ToArray();
            }
            if (original.Width > original.Height)
            {
                newWidth = newMaxWidth;
                newHeight = (int)(((float)newWidth / 
                    (float)original.Width) * (float)original.Height);
            }
            else
            {
                newHeight = newMaxHeight;
                newWidth = (int)(((float)newHeight / 
                    (float)original.Height) * (float)original.Width);
            }
            //original.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero)
            //    .Save(thumbData, ImageFormat.Jpeg);
            //return thumbData.ToArray();
            using (Image thumb = new Bitmap(newWidth, newHeight))
            {
                Graphics g = Graphics.FromImage(thumb);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(original, 0f, 0f, (float)newWidth, (float)newHeight);
                thumb.Save(thumbData, ImageFormat.Jpeg);
            }
        }
    }
