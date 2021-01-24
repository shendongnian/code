    public static System.Drawing.Drawing2D.GraphicsPath Transparent(Image im)
    {
        int x;
        int y;
        Bitmap bmp = new Bitmap(im);
        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        Color mask = bmp.GetPixel(0, 0);
        for (x = 0; x <= bmp.Width - 1; x++)
        {
            for (y = 0; y <= bmp.Height - 1; y++)
            {
                if (!bmp.GetPixel(x, y).Equals(mask))
                {
                    gp.AddRectangle(new Rectangle(x, y, 1, 1));
                }
            }
        }
        bmp.Dispose();
        return gp;
    }
