    using (MemoryStream imageSource = new MemoryStream())
    {
        imageSource.Write(
               blogPhoto.BlogPhotoImage, 0, 
               blogPhoto.BlogPhotoImage.Length);
        using (Image img = Image.FromStream(imageSource))
        {
            img.Save(imageSource, ImageFormat.Jpeg);
            int newWidth;
            int newHeight;
            if (img.Width > img.Height)
            {
                if (img.Width <= newMaxWidth)
                    return imageSource.ToArray();
                newWidth = newMaxWidth;
                newHeight = (int)(((float)newWidth / (float)img.Width)
                                                   * (float)img.Height);
            }
            else
            {
                if (img.Height <= newMaxHeight)
                    return imageSource.ToArray();
                newHeight = newMaxHeight;
                newWidth = (int)(((float)newHeight / (float)img.Height)
                                                   * (float)img.Width);
            }
            Image thumb = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(thumb);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(img, 0f, 0f, (float)newWidth, (float)newHeight);
            thumb.Save(imageSource, ImageFormat.Jpeg);
            return imageSource.ToArray();
        }
    }
