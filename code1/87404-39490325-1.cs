    A AClass = new B();
    Console.WriteLine(AClass.Foo());
    B BClass = new B();
    Console.WriteLine(BClass.Foo());
    B BClassWithC = new C();
    Console.WriteLine(BClassWithC.Foo());
    
    Console.WriteLine(AClass.Test());
    Console.WriteLine(BClassWithC.Test());
