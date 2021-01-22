    var flattened = path.Data.GetFlattenedPathGeometry();
    var segment = pg.Figures[0].Segments[0] as PolyLineSegment;
    Point[] points = segment.Points;
    for(int i=0; i<points.Count-1; i++)
    {
      ... check for intersection with the line from points[i] to points[i+1] ...
    }
