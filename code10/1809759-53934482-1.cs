    Image Img = new Bitmap(this.Picturebox1.Width, this.Picturebox1.Height);
    Graphics g = Graphics.FromImage(Img);
    SolidBrush bgBrush = new SolidBrush(Color.LightSlateGray);
    Pen shPen = new Pen(Color.Black);
    Point[] pts;
    pts = new[] { new Point(150, 100), new Point(200, 100), new Point(150, 200), new Point(200, 200) };         // 4
    GraphicsPath pth = new GraphicsPath();
    pth = ShapeData(0);
    g.FillPath(bgBrush, pth);            // fill
    g.DrawPath(shPen, pth);              // border
    Int16 Angle = 30;
    Matrix RotMatrix = new Matrix();                    // rotate matrix to put the shape back to initial coordinates (with bottom left point as reference)
    RotMatrix.Rotate(Angle, MatrixOrder.Append);        // Rotate the pattern to the desired angle
    RotMatrix.TransformPoints(pts);                     // carry out matrix transformation over the shape points
