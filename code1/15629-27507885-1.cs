    public static class GeometryHelper
    {
    public static PointCollection TransformPoints(PointCollection pc, Transform t)
    {
      PointCollection tp = new PointCollection(pc.Count);
      foreach (Point p in pc)
        tp.Add(t.Transform(p));
      return tp;
    }
    public static PathGeometry TransformedGeometry(PathGeometry g, Transform t)
    {
      Matrix m = t.Value;
      double scaleX = Math.Sqrt(m.M11 * m.M11 + m.M21 * m.M21);
      double scaleY = (m.M11 * m.M22 - m.M12 * m.M21) / scaleX;
      PathGeometry ng = g.Clone();
      foreach (PathFigure f in ng.Figures)
      {
        f.StartPoint = t.Transform(f.StartPoint);
        foreach (PathSegment s in f.Segments)
        {
          if (s is LineSegment)
            (s as LineSegment).Point = t.Transform((s as LineSegment).Point);
          else if (s is PolyLineSegment)
            (s as PolyLineSegment).Points = TransformPoints((s as PolyLineSegment).Points, t);
          else if (s is BezierSegment)
          {
            (s as BezierSegment).Point1 = t.Transform((s as BezierSegment).Point1);
            (s as BezierSegment).Point2 = t.Transform((s as BezierSegment).Point2);
            (s as BezierSegment).Point3 = t.Transform((s as BezierSegment).Point3);
          }
          else if (s is PolyBezierSegment)
            (s as PolyBezierSegment).Points = TransformPoints((s as PolyBezierSegment).Points, t);
          else if (s is QuadraticBezierSegment)
          {
            (s as QuadraticBezierSegment).Point1 = t.Transform((s as QuadraticBezierSegment).Point1);
            (s as QuadraticBezierSegment).Point2 = t.Transform((s as QuadraticBezierSegment).Point2);
          }
          else if (s is PolyQuadraticBezierSegment)
            (s as PolyQuadraticBezierSegment).Points = TransformPoints((s as PolyQuadraticBezierSegment).Points, t);
          else if (s is ArcSegment)
          {
            ArcSegment a = s as ArcSegment;
            a.Point = t.Transform(a.Point);
            a.Size = new Size(a.Size.Width * scaleX, a.Size.Height * scaleY); // NEVER TRIED
          }
        }
      }
      return ng;
    }
    }
    
 
