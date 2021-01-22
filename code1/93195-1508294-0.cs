    /// <summary>
    /// Add a border to an image
    /// </summary>
    /// <param name="srcImg"></param>
    /// <param name="color">The color of the border</param>
    /// <param name="width">The width of the border</param>
    /// <returns></returns>
    public static Image AddBorder(this Image srcImg, Color color, int width)
    {
        // Create a copy of the image and graphics context
        Image dstImg = srcImg.Clone() as Image;
        Graphics g = Graphics.FromImage(dstImg);
        // Create the pen
        Pen pBorder = new Pen(color, width)
        {
            Alignment = PenAlignment.Center
        };
        // Draw
        g.DrawRectangle(pBorder, 0, 0, dstImg.Width, dstImg.Height);
        // Clean up
        pBorder.Dispose();
        g.Save();
        g.Dispose();
        // Return
        return dstImg;
    }
