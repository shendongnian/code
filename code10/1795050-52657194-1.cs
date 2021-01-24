      public class PointList
        {
            public string Bla { get; set; }
    
            public List<Point> Points { get; protected set; } = new List<Point>();
    
            public void AddPoint(int x, int y)
            {
                AddPointPrivate(new Point(x, y));
            }
            public void AddPoint(Point p)
            {
                AddPointPrivate(p);
            }
            private void AddPointPrivate(Point point)
            {
                if (!Points.Any(x => x.Equals(point)))
                    Points.Add(point);
            }
            public void RemovePoint(int x, int y)
            {
                RemovePointPrivate(new Point(x, y));
            }
            private void RemovePointPrivate(Point p)
            {
                Points.Remove(p);
            }
            public void RemovePoint(Point point)
            {
                RemovePointPrivate(point);
            }
            public Point GetPoint(int x, int y)
            {
                return GetPrivatePoint(new Point(x, y));
            }
            private Point GetPrivatePoint(Point point)
            {
                return Points.FirstOrDefault(x => x.Equals(point));
            }
    
            public Point GetPoint(Point point)
            {
                return GetPrivatePoint(point);
            }
    
    
    
        }
