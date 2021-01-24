    static Demo Test()
    {
       return StaticDemoInstance;
    }
    ...
    GetDemo() = new Demo("UpdatedDemoFromGetMeth", false);
    var someObject = Test();
    someObject= new Demo("Test", false);
    Console.WriteLine(StaticDemoInstance.Name);
    Console.WriteLine(someObject.Name);
