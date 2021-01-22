    using System.Drawing;
    ...
    Font font = new Font(FontFamily.GenericMonospace, 10);
    Image reportImage = new Bitmap(220, 60);
    using (Graphics graphics = Graphics.FromImage(reportImage))
    {
        graphics.SmoothingMode = 
            System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        graphics.FillRectangle(Brushes.White, 
            new Rectangle(new Point(0, 0), reportImage.Size));
        for (int i = 0; i != 6; i++)
        {
            Rectangle r = new Rectangle(20 + i * 30, 20, 20, 20);
            graphics.FillEllipse(Brushes.DarkOrange, r);
            graphics.DrawEllipse(Pens.Black, r);
            r.Offset(1, 1);
            graphics.DrawString(i.ToString(), font, Brushes.Black, r);
        }
    }
    reportImage.Save("C:\\test.bmp");
