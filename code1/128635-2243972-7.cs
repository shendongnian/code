    DerivedClass d = new DerivedClass();
    d.MyProperty = 42;
    
    BaseClass b = d;
    Console.WriteLine(b.MyProperty);  // prints 1
