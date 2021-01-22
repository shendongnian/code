    public static System.Drawing.Size MaxSizeThumbnail(this System.Drawing.Size CurrentDimensions, int maxWidth, int maxHeight)
    {
        int newHeight = CurrentDimensions.Height;
        int newWidth = CurrentDimensions.Width;
        if (maxWidth > 0 && newWidth > maxWidth) //WidthResize
        {
            Decimal divider = Math.Abs((Decimal)newWidth / (Decimal)maxWidth);
            newWidth = maxWidth;
            newHeight = (int)Math.Round((Decimal)(newHeight / divider));
        }
        if (maxHeight > 0 && newHeight > maxHeight) //HeightResize
        {
            Decimal divider = Math.Abs((Decimal)newHeight / (Decimal)maxHeight);
            newHeight = maxHeight;
            newWidth = (int)Math.Round((Decimal)(newWidth / divider));
        }
        return new System.Drawing.Size(newWidth, newHeight);
    }
