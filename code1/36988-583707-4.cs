    TestObject obj1 = new TestObject(),
               obj2 = new TestObject();
    obj1.IsActive = obj2.IsActive = S2kBool.True;
            
    Console.WriteLine(obj1.IsActive);
    Console.WriteLine(obj2.IsActive);
    obj1.IsActive.Value = false;
    Console.WriteLine(obj1.IsActive);
    Console.WriteLine(obj2.IsActive); // what does this print?
