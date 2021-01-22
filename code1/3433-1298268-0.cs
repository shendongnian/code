    static void DoSomething(IFoo foo) {Console.WriteLine("working happily") }
    static void DoSomething(Foo foo) {Console.WriteLine("formatting hard disk...");}
    
    // this working code...
    IFoo oldCode = new Foo();
    DoSomething(oldCode);
    // ...is **very** different to this code
    var newCode = new Foo();
    DoSomething(newCode);
 
