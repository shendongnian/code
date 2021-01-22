    void DrawSpring (Graphics g)
    {
        List<Point> points = new List<Point>();
        double step = 0.01;
        for(double t = -2; t < 2; t += step)
        {
            Point p = new Point();
            p.X = XPartOfTheEquation(t);
            p.Y = YPartOfTheEquation(t);
            points.Add(p);
         }
        g.DrawLines(new Pen(new SolidBrush(Color.Black), 2f), points.ToArray());
    }
