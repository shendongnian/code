    using System.Drawing;
    ...
    Font font = new Font(FontFamily.GenericMonospace, 8);
    Image reportImage = new Bitmap(270, 45);
    using (Graphics graphics = Graphics.FromImage(reportImage))
    {
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        graphics.InterpolationMode = 
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphics.FillRectangle(Brushes.White, 
            new Rectangle(new Point(0, 0), reportImage.Size));
        for (int i = 0; i != 6; i++)
        {
            Rectangle r = new Rectangle(20 + i * 40, 15, 25, 15);
            graphics.FillEllipse(
                i % 2 == 0 ? Brushes.DarkOrange : Brushes.DarkKhaki, r);
            graphics.DrawEllipse(Pens.Black, r);
            r.Offset(2, 0);
            graphics.DrawString(i.ToString(), font, Brushes.Black, r);
        }
    }
    reportImage.Save("C:\\test.bmp");
