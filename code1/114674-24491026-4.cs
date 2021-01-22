    public static Size ResizeKeepAspect(Size src, int maxWidth, int maxHeight)
    {
        decimal rnd = Math.Min(maxWidth / (decimal)src.Width, maxHeight / (decimal)src.Height);
        return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
    }
