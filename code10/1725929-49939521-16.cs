    int pointCount = 10;
    Bitmap bmp = new Bitmap(2, chart.ClientSize.Height / pointCount - 5);
    using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.Black);
    NamedImage marker = new NamedImage("marker", bmp);
    chart.Images.Clear();  // quick & dirty
    chart.Images.Add(marker);
