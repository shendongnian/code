    A clA = new A();
    B clB = new B();
    
    Console.Writeline(clA.Foo()); // output 5
    Console.Writeline(clA.Bar()); // output 5
    Console.Writeline(clB.Foo()); // output 1
    Console.Writeline(clB.Bar()); // output 1
    
    //now let's cast B to an A class
    Console.Writeline((A)clB.Foo()); // output 5 <<<--
    Console.Writeline((A)clB.Bar()); // output 1
