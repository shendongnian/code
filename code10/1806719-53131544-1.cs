    var a = new MyObject
    {
       prop1 = "abc", // same value
       prop2 = "def",
       prop3 = 123,
       prop4 = 456 // same value
    };
    
    var b = new MyObject
    {
       prop1 = "abc", // same value
       prop2 = "jkl",
       prop3 = 789,
       prop4 = 456 // same value
    };
    
    Console.WriteLine(CompareProps(a, b)); // output 2
