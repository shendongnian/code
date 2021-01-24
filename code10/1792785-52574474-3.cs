    // create class
    var someClass = new MyClass();
    // create some memory for it
    someClass.Foo1 = new Foo();
    someClass.Foo1.SomeValue = "test";
    // copy the reference to it
    var copy = someClass.Foo1; 
    // overwrite it
    copy = new Foo();
    copy.SomeValue = "test2";
    // oh nossssssssss!!!! is didn't change!!
    Console.WriteLine(someClass.Foo1.SomeValue);
    //enter ref local
    ref var  actualLocation = ref someClass.ModifyMyClass();
    // create some memory
    actualLocation = new Foo();
    actualLocation.SomeValue = "test3";
    // omg it worked!!!!
    Console.WriteLine(someClass.Foo1.SomeValue);
