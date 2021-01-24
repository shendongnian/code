        public class PointList
    {
        public string Bla { get; set; }
        public List<Point> Points { get; protected set; } = new List<Point>();
        public void AddPoint(int x, int y)
        {
            AddPoint(new Point(x, y));
        }
        public void AddPoint(Point p)
        {
            if (!Points.Any(x => x.Equals(p)))
                Points.Add(p);
        }
        public void RemovePoint(int x, int y)
        {
            RemovePoint(new Point(x, y));
        }
        public void RemovePoint(Point point)
        {
            Points.Remove(point);
        }
        public Point GetPoint(int x, int y)
        {
            return GetPoint(new Point(x, y));
        }
        public Point GetPoint(Point point)
        {
            return Points.FirstOrDefault(x => x.Equals(point));
        }
    }
