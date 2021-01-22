    /// <summary>
    /// method to rotate an image either clockwise or counter-clockwise
    /// </summary>
    /// <param name="img">the image to be rotated</param>
    /// <param name="rotationAngle">the angle (in degrees).
    /// NOTE: 
    /// Positive values will rotate clockwise
    /// negative values will rotate counter-clockwise
    /// </param>
    /// <returns></returns>
    public static Image RotateImage(Image img, float rotationAngle)
    {
        //create an empty Bitmap image
        Bitmap bmp = new Bitmap(img.Width, img.Height);
    
        //turn the Bitmap into a Graphics object
        Graphics gfx = Graphics.FromImage(bmp);
    
        //now we set the rotation point to the center of our image
        gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
    
        //now rotate the image
        gfx.RotateTransform(rotationAngle);
    
        gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
    
        //set the InterpolationMode to HighQualityBicubic so to ensure a high
        //quality image once it is transformed to the specified size
        gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
        //now draw our new image onto the graphics object
        gfx.DrawImage(img, new Point(0, 0));
    
        //dispose of our Graphics object
        gfx.Dispose();
    
        //return the image
        return bmp;
    }
