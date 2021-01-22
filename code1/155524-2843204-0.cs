    GraphicsPath UpdateGraphicsPath(GraphicsPath gP, RectangleF rF, PointF delta)
    {
        // Find the points in gP that are inside rF and move them by delta.
        
        PointF[] updatePoints = gP.PathData.Points;
        byte[] updateTypes = gP.PathData.Types;
        for (int i = 0; i < gP.PointCount; i++)
        {
            if (rF.Contains(updatePoints[i]))
            {
                updatePoints[i].X += delta.X;
                updatePoints[i].Y += delta.Y;
            }
        }
        return new GraphicsPath(updatePoints, updateTypes);
    }
