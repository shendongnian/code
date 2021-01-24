    public interface IPoint
    {
        void Print();
    }
    class Point2D : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Print()
        {
            Console.WriteLine($"2D Point: [{X}, {Y}]");
        }
    }
    class Point3D : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public void Print()
        {
            Console.WriteLine($"3D Point: [{X}, {Y}, {Z}]");
        }
    }
    class Drawing2D
    {
        public string Name { get; set; }
        public List<IPoint> Points { get; set; }
        public Drawing2D(string name)
        {
            Name = name;
            Points = new List<IPoint>();
        }
        public void Print()
        {
            Console.WriteLine($"Drawing name: {Name}");
            foreach (var point in Points)
                point.Print();
        }
    }
    
    class Drawing3D : Drawing2D
    {
        public Drawing3D(string name) : base(name) { }
    }
