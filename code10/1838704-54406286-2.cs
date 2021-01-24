    var a = new A();
    var b = new B();
    var c = new C();
    var objectholder = new Objectholder();
    objectholder.AddObject(a);
    objectholder.AddObject(b);
    objectholder.AddObject(c);
    // Contains A and B and C
    var allA = objectholder.GetObjectsOf<A>().ToArray();
