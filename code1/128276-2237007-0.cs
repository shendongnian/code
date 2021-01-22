    myIntArr.Select(i => new MyTestObj(i));
    // or...
    myIntArr.Select(i => (MyTestObj)i);
    // or...
    myIntArr.Select(i => new MyTestObj { SomeProperty = i });
    
    
