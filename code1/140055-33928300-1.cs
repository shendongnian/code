    // simple struct which represents a point in three-dimensional space
    public struct Point3D
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    // implementation of a collection of points, which respects
    // the compiler convention for collection initializers and
    // therefore both implements IEnumerable<T> and provides
    // a public Add method
    public class Points : IEnumerable<Point3D>
    {
        private readonly List<Point3D> _points;
        public Points()
        {
            _points = new List<Point3D>();
        }
        public void Add(double x, double y, double z)
        {
            _points.Add(new Point3D(x, y, z));
        }
        public IEnumerator<Point3D> GetEnumerator()
        {
            return _points.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    // instantiate the Points class and fill it with values like this:
    var cube = new Points
    {
        { -1, -1, -1 },
        { -1, -1,  1 },
        { -1,  1, -1 },
        { -1,  1,  1 },
        {  1, -1, -1 },
        {  1, -1,  1 },
        {  1,  1, -1 },
        {  1,  1,  1 }
    };
