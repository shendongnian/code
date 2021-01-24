    MyClass a = new MyClass();
    MyClass b = new MyClass();
    ...
    a.Words = b.Words;
    a.Add("abc");
    // "abc": a and b share the same list
    Console.Write(b.Words.LastOrDefault()); 
