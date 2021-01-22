    Foo a = new Foo(1);
    Foo b = a; //a, b point to the same object
    
    b.Value = 4; // change property
    Assert.Equals(a.Value, 4); //true - changed for a
    
    b = new Foo(600); // new reference for b
    Assert.Equals(a.Value, 4); //true
    Assert.Equals(b.Value, 600); //true
