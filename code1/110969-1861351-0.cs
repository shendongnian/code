    /// <summary>
    /// Resizes a square image
    /// </summary>
    /// <param name="OriginalImage">Image to resize</param>
    /// <param name="Size">Width and height of new image</param>
    /// <returns>A scaled version of the image</returns>
    internal static Image ResizeImage( Image OriginalImage, int Size )
    {
        Image finalImage = new Bitmap( Size, Size );
        Graphics graphic = Graphics.FromImage( finalImage );
        graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        Rectangle rectangle = new Rectangle( 0, 0, Size, Size );
        graphic.DrawImage( OriginalImage, rectangle );
        return finalImage;
    }
