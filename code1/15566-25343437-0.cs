    public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, Size size)
    {
        return ResizeImage(image, size.Width, size.Height);
    }
    public static Size GetProportionedSize(Image image, int maxWidth, int maxHeight, bool withProportion)
    {
        if (withProportion)
        {
            double sourceWidth = image.Width;
            double sourceHeight = image.Height;
            if (sourceWidth < maxWidth && sourceHeight < maxHeight)
            {
                maxWidth = (int)sourceWidth;
                maxHeight = (int)sourceHeight;
            }
            else
            {
                double aspect = sourceHeight / sourceWidth;
                if (sourceWidth < sourceHeight)
                {
                    maxWidth = Convert.ToInt32(Math.Round((maxHeight / aspect), 0));
                }
                else
                {
                    maxHeight = Convert.ToInt32(Math.Round((maxWidth * aspect), 0));
                }
            }
        }
        return new Size(maxWidth, maxHeight);
    }
