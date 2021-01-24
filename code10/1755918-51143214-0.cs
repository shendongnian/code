    //Set things up...
    List<MyClass> myObjects = new List<MyClass>
    {
        new MyClass{Number = 23},
        new MyClass{Number = 42},
        new MyClass{Number = 66}
    };
    int [] numbers = new int[myObjects.Count];
    //answer your question...
    var i = 0;
    foreach (var myObj in myObjects)
    {
        numbers[i] = myObj.Number;
        ++i;
    }
