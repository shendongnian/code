    SomeClass a = new SomeClass();
    SomeClass b = new SomeClass();
    SomeClass c = new SomeClass();
    a.SetEdges(b, c);
    b.SetEdges(a, c);
    c.SetEdges(a, b);
