    public bool IsColliding(Vector2 point)
        {
            GraphicsPath gp = new GraphicsPath();
            Vector2 prevPoint = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                Vector2 currentPoint = points[i];
                gp.AddLine(prevPoint.X, prevPoint.Y, currentPoint.X, currentPoint.Y);
                prevPoint = currentPoint;
            }
            gp.CloseFigure();   //closing line segment
            Region r = new Region(gp);
            return r.IsVisible(point.X, point.Y);
        }
