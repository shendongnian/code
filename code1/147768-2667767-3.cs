    public static Image EnlargeImage(this Image original, int scale)
    {
        Bitmap newimg = new Bitmap(original.Width * scale, original.Height * scale);
        Graphics gr = Graphics.FromImage(newimg);
        // Here you set your interpolation mode
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
        // Scale the image, by drawing it on the larger bitmap
        gr.DrawImage(original, new Rectangle(Point.Empty, newimg.Size));
        return newimg;
    }
