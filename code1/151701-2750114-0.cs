    struct X
    {
        public int ID;
        public string Name;
    }
    X x1 = new X { ID = 1, Name = "Foo" };
    X x2 = x1;
    x2.Name = "Bar";
    Console.WriteLine(x1.Name);    // Will print "Foo"
    class Y
    {
        public int ID;
        public string Name;
    }
    Y y1 = new Y { ID = 2, Name = "Bar" };
    Y y2 = y1;
    y2.Name = "Baz";
    Console.WriteLine(y1.Name);    // Will print "Baz"
