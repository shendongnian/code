    StartPoint = e.GetPosition(monDessin);
    double distance=-1;
    double dist;
    Shape selectedShape = null;
    for (int i = monDessin.Children.Count - 1; i > -1; i--)
    {
        string type = monDessin.Children[i].GetType().ToString();
        
        if (monDessin.Children[i] is Ellipse)
        {
            Ellipse ell = (Ellipse)monDessin.Children[i];
            double x = ell.Margin.Left + ell.Width / 2;
            double y = ell.Margin.Top - ell.Height / 2;
            dist = Math.Sqrt((StartPoint.X - x) * (StartPoint.X - x) + (StartPoint.Y -y) * (StartPoint.Y - y));
            if(distance==-1 || dist<distance)
            {
                distance = dist;
            }
        }
        else if(monDessin.Children[i] is Path)
            {
                Path path=(Path)monDessin.Children[i];
                string titi = path.Tag.GetType().ToString();
                Geometry geometry = path.Data;
                PathGeometry pathGeometry = geometry.GetOutlinedPathGeometry();
                PathFigureCollection figures = pathGeometry.Figures;
                if (figures != null)
                {
                   foreach (PathFigure figure in figures)
                   {
                       foreach (PathSegment segment in figure.Segments)
                       {
                           //first syntax : if(segment is LineSegment)
                           if(segment is LineSegment)
                           {
                              LineSegment lineSegment = (LineSegment)segment;
                              double x = lineSegment.Point.X;
                              ouble y = lineSegment.Point.Y;
                           }
                           //2nd syntax : 
                           //ArcSegment arcSegment = segment as ArcSegment;
                           //Then check if not null
                           ArcSegment arcSegment = segment as ArcSegment;
                           if (arcSegment != null)
                           {
                               double x = arcSegment.Point.X;
                               double y = arcSegment.Point.Y;
                               dist = Math.Sqrt((StartPoint.X - x) * (StartPoint.X - x) + (StartPoint.Y - y) * (StartPoint.Y - y));
                               if (distance == -1 || dist < distance)
                               {
                                   distance = dist;
                               }
                           }
                           BezierSegment bezierSegment = segment as BezierSegment;
                           if (bezierSegment != null)
                           {
                               double x = bezierSegment.Point3.X;
                               double y = bezierSegment.Point3.Y;
                               dist = Math.Sqrt((StartPoint.X - x) * (StartPoint.X - x) + (StartPoint.Y - y) * (StartPoint.Y - y));
                               if (distance == -1 || dist < distance)
                               {
                                    distance = dist;
                               }
                           }
                       }
                  }
              }
         }
    }
