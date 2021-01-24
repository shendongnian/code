    public static Rectangle GetNewRectangle(Size oldSize, Rectangle oldRectangle, 
        Size newSize)
    {
        var percentChangeX = (double)newSize.Width / oldSize.Width;
        var percentChangeY = (double)newSize.Height / oldSize.Height;
        return new Rectangle
        {
            X = (int)(oldRectangle.X * percentChangeX),
            Y = (int)(oldRectangle.Y * percentChangeY),
            Width = (int)(oldRectangle.Width * percentChangeX),
            Height = (int)(oldRectangle.Height * percentChangeY)
        };
    }
