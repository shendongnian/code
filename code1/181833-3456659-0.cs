    class Program
    {
        private class MyType
        {
            private readonly Point _location;
            public MyType(Point location)
            {
                _location = location;
            }
            public Point Location
            {
                get
                {
                    return _location;
                }
            }
        }
        static void Main( string[] args )
        {
            var someInstance = new MyType (new Point (5, 6));
            someInstance.Location.X = 5; // <- compiler error: cannot modify the expression because it is not a variable.
        }
