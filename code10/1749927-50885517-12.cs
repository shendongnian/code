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
    public virtual void Print()
    {
        Console.WriteLine("2D Point: [{"+X+"}, {"+Y+"}]");
    }
    }
    class Point3D:Point2D, IPoint
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z):base(x,y)
        {
            Z = z;
        }
        public override void Print()
        {
            Console.WriteLine("3D Point: [{"+X+"}, {"+Y+"}, {"+Z+"}]");
        }
    }
 
