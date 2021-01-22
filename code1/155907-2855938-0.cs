    protected override System.Windows.Media.Geometry DefiningGeometry
    {
        get
        {
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext context = geometry.Open())
            {
                context.BeginFigure(Points[0], false, true);
                foreach (Point pt in Points)
                {
                    context.LineTo(pt, true, true);
                }
                geometry.Freeze();
                return geometry;
            }
        }
    }
