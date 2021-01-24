    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    string text = "This is my Text";
    Font font = new Font("Mistral", 52, FontStyle.Regular, GraphicsUnit.Point);
    float penSize = 1f;
    using (GraphicsPath path = new GraphicsPath())
    {
        path.AddString(text, font.FontFamily, (int)font.Style, font.Size, Point.Empty, StringFormat.GenericTypographic);
        RectangleF textBounds = path.GetBounds();
        using (Bitmap bitmap = new Bitmap((int)textBounds.Width, (int)textBounds.Height, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.Clear(Color.Black);
            g.TranslateTransform(-penSize, -(textBounds.Y + penSize));
            using (SolidBrush brush = new SolidBrush(Color.LightGreen))
            {
                g.FillPath(brush, path);
            }
            bitmap.Save("[Image Path]", ImageFormat.Png);
            //Or: return (Bitmap)bitmap.Clone();
        }
    }
