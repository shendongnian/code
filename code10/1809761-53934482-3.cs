    Image Img = new Bitmap(this.Picturebox1.Width, this.Picturebox1.Height);
    Graphics g = Graphics.FromImage(Img);
    SolidBrush bgBrush = new SolidBrush(Color.LightSlateGray);
    Pen shPen = new Pen(Color.Black);
    Point[] pts;
    pts = new[] { new Point(150, 100), new Point(210, 110), new Point(140, 200), new Point(200, 210) };         // 4
    GraphicsPath pth = new GraphicsPath();
    pth = ShapeData(0);
    g.FillPath(bgBrush, pth);            // fill
    g.DrawPath(shPen, pth);              // border
