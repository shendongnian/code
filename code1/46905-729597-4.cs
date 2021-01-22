    Base b = new Base();//base class
    Derived d = new Derived();//derived class
    
    b.DoStuff();    // OK
    d.DoStuff();    // Also OK
    b.DoOtherStuff();    // Won't work!
    d.DoOtherStuff();    // OK
    
    d = new Derived(b);  // Copy construct a Derived with values of b
    d.DoOtherStuff();    // Now works!
