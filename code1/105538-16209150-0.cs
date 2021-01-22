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
    c.Origin = new Point { X = 23 }; //even though you are invoking the default ctor
