    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class MyClass
    {
        public Point Origin { get; set; }
    }
    MyClass c = new MyClass();
    c.Origin.X = 23; //fails.
    //but you could do:
    c.Origin = new Point { X = 23, Y = c.Origin.Y }; //though you are invoking default constructor
    //instead of
    c.Origin = new Point(23, c.Origin.Y); //in case there is no constructor like this.
