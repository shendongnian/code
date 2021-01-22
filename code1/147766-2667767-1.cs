    public static Image EnlargeImage(this Image original, int scale)
    {
        Bitmap newimg = new Bitmap(original.Width * scale, original.Height * scale);
        Graphics gr = Graphics.FromImage(newimg);
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
        gr.DrawImage(original, new Rectangle(Point.Empty, newimg.Size));
        return newimg;
    }
