    A clA = new A();
    B clB = new B();
    
    Console.WriteLine(clA.Foo()); // output 5
    Console.WriteLine(clA.Bar()); // output 5
    Console.WriteLine(clB.Foo()); // output 1
    Console.WriteLine(clB.Bar()); // output 1
    
    //now let's cast B to an A class
    Console.WriteLine(((A)clB).Foo()); // output 5 <<<--
    Console.WriteLine(((A)clB).Bar()); // output 1
