    // using System.Drawing;
    // using System.Drawing.Imaging;
    // using System.Drawing.Drawing2D;
    public static void OutputGradientImage()
    {
        using (Bitmap bitmap = new Bitmap(100, 100)) // 100x100 pixels
        using (Graphics graphics = Graphics.FromImage(bitmap))
        using (LinearGradientBrush brush = new LinearGradientBrush(
            new Rectangle(0, 0, 100, 100),
            Color.Blue,
            Color.Red,
            LinearGradientMode.Vertical))
        {
            brush.SetSigmaBellShape(0.5f);
            graphics.FillRectangle(brush, new Rectangle(0, 0, 100, 100));
            bitmap.Save("gradientImage.jpg", ImageFormat.Jpeg);
        }
    }
