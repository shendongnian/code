    baseClassDelegate a = Foo1; // works fine 
    derivedClassDelegate b = Foo2; // works fine 
    b = new derivedClassDelegate(a.Invoke); // the easy way to assign delegate using variance, adds layer of indirection though 
    b(new Derived());
    b = CastDelegate<derivedClassDelegate>(a); // the hard way, avoids indirection 
    b(new Derived());
