    using (Bitmap b = new Bitmap(160, 160))
    using (Graphics g = Graphics.FromImage(b))
    {
        g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 79, 79);
        g.FillRectangle(new SolidBrush(Color.Red), 79, 0, 159, 79);
        g.FillRectangle(new SolidBrush(Color.Green), 0, 79, 79, 159);
        g.FillRectangle(new SolidBrush(Color.Yellow), 79, 79, 159, 159);
        b.Save(@"c:\test.bmp");
    }
