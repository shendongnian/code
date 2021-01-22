    /// <summary>
    ///    Resize image with GDI+ so that image is nice and clear with required size.
    /// </summary>
    /// <param name="SourceImage">Image to resize</param>
    /// <param name="NewHeight">New height to resize to.</param>
    /// <param name="NewWidth">New width to resize to.</param>
    /// <returns>Image object resized to new dimensions.</returns>
    /// <remarks></remarks>
    public static Image ImageResize(Image SourceImage, Int32 NewHeight, Int32 NewWidth)
    {
       System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(NewWidth, NewHeight, SourceImage.PixelFormat);
     
       if (bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Format1bppIndexed | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Format4bppIndexed | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Format8bppIndexed | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Undefined | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.DontCare | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Format16bppArgb1555 | bitmap.PixelFormat == Drawing.Imaging.PixelFormat.Format16bppGrayScale) 
       {
          throw new NotSupportedException("Pixel format of the image is not supported.");
       }
       
       System.Drawing.Graphics graphicsImage = System.Drawing.Graphics.FromImage(bitmap);
       
       graphicsImage.SmoothingMode = Drawing.Drawing2D.SmoothingMode.HighQuality;
       graphicsImage.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
       graphicsImage.DrawImage(SourceImage, 0, 0, bitmap.Width, bitmap.Height);
       graphicsImage.Dispose();
       return bitmap; 
    }
