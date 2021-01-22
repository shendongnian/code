    /// <summary>
    /// 
    /// </summary>
    /// <param name="img"></param>
    /// <param name="size">Size of the constraining proportion</param>
    /// <param name="constrainOnWidth"></param>
    /// <returns></returns>
    public static System.Drawing.Image ResizeConstrainProportions(this System.Drawing.Image img,
        int size, bool constrainOnWidth, bool dontResizeIfSmaller)
    {
        if (dontResizeIfSmaller && (img.Width < size))
            return img;
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX); 
        img.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
        float ratio = 0;
        ratio = (float)img.Width / (float)img.Height;
        int height, width = 0;
        if (constrainOnWidth)
        {
            height = (int)(size / ratio);
            width = size;
        }
        else
        {
            width = (int)(size * ratio);
            height = size;
        }
        return img.GetThumbnailImage(width, height, null, (new System.IntPtr(0)));
    }
