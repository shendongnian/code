    public abstract class Point
        {
           public abstract void Print();
        }
    
        class Point2D : Point
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public Point2D(int x, int y)
            {
                X = x;
                Y = y;
            }
    
            public override void Print()
            {
                Console.WriteLine($"2D Point: [{X}, {Y}]");
            }
        }
    
        class Point3D : Point2D
        {
            public int Z { get; set; }
    
            public Point3D(int x, int y, int z) : base(x, y)
            {
                Z = z;
            }
    
            public override void Print()
            {
                Console.WriteLine($"3D Point: [{X}, {Y}, {Z}]");
            }
        }
        
    
        class Drawing<T> where T:Point
        {
            public string Name { get; set; }
            public virtual List<T> Points { get; set; }
    
            public Drawing(string name)
            {
                Name = name;
                Points = new List<T>();
            }
    
            public void Print()
            {
                Console.WriteLine($"Drawing name: {Name}");
                foreach (var point in Points)
                    point.Print();
            }
        }
    
        class Drawing3D : Drawing<Point3D>
        {
            public Drawing3D(string name) : base(name)
            {
                Name = name;            
            }
        }
    
        class Drawing2D : Drawing<Point2D>
        {
            public Drawing2D(string name) : base(name)
            {
                Name = name;
            }
        }
