    private Geometry ConvertToGeometry(Shape s)
        {
            if (s.GetType() == new Rectangle().GetType())
            {
                return new RectangleGeometry(new Rect(new Point(s.Margin.Left, s.Margin.Top), new Point(s.Margin.Left + s.Width, s.Margin.Top + s.Height)));
            }
            if (s.GetType() == new Ellipse().GetType())
            {
                return new EllipseGeometry(new Point(s.Width / 2 + s.Margin.Left, s.Height / 2 + s.Margin.Top), s.Width / 2, s.Height / 2);
            }
            if (s.GetType() == new Polygon().GetType())
            {
                Polygon p = (Polygon)s;
                List<PathSegment> ps = new List<PathSegment>();
                for (int i = 1; i < p.Points.Count; i++)
                {
                    ps.Add(new LineSegment(p.Points[i], true));
                }
                PathGeometry pg = new PathGeometry(new PathFigure[] { new PathFigure(p.Points[0], ps, true) });
                return pg;
            }
            return null;
        }
