    Matrix M = new Matrix();
    // just a rectangle for testing..
    Rectangle R = panel1.ClientRectangle;
    R.Inflate(-33,-33);
    // create an array of all corner points:
    var p = new PointF[] {
        R.Location,
        new PointF(R.Right, R.Top),
        new PointF(R.Right, R.Bottom),
        new PointF(R.Left, R.Bottom) };
    // rotate by 15° around the center point:
    M.RotateAt(15, new PointF(R.X + R.Width / 2, R.Top + R.Height / 2));
    M.TransformPoints(p);
    // just a quick (and dirty!) test:
    using (Graphics g = panel1.CreateGraphics())
    {
        g.DrawRectangle(Pens.LightBlue, R);
        g.DrawPolygon(Pens.DarkGoldenrod, p );
    }
