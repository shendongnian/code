    struct Point
    {
        public int X { get; set; }
    }
    class MyClass
    {
        public Point Origin { get; set; }
    }
    MyClass c = new MyClass();
    c.Origin.X = 23; //fails.
    //but you could do:
    c.Origin = new Point { X = 23, Y = Origin.Y }; //though u r invoking default ctor
    //instead of
    c.Origin = new Point(23, Origin.Y); //in case there is no constructor like this.
