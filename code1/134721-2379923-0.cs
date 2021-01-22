    /// <summary>
    /// Point in polygon check.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="polygon">The polygon.</param>
    /// <returns>True if point is inside, false otherwise.</returns>
    /// <see cref="http://local.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/"/>
    public bool PointInPolygon(Point point, Polygon polygon) {
    
           bool inside = false;
    
                foreach (var side in polygon.Lines) {
                    if (point.Y > Math.Min(side.Start.Y, side.End.Y))
                        if (point.Y <= Math.Max(side.Start.Y, side.End.Y))
                            if (point.X <= Math.Max(side.Start.X, side.End.X)) {
                                float xIntersection = side.Start.X + ((point.Y - side.Start.Y) / (side.End.Y - side.Start.Y)) * (side.End.X - side.Start.X);
                                if (point.X <= xIntersection)
                                    inside = !inside;
                            }
                }
    
                return inside;
            }
