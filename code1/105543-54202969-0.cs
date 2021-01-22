    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    class MyClass
    {
        public Point Origin;
    }
    
    MyClass c = new MyClass();
    c.Origin.X = 23;   // No error.  Sets X just fine
