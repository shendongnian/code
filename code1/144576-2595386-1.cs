    MyClass a = new MyClass() { ID = 123, Name = "Apple" };
    MyClass b = new MyClass() { ID = 456, Name = "Banana" };
    MyClass c = new MyClass() { ID = 789, Name = "Cherry" };
    MyClass d = new MyClass() { ID = 123, Name = "Alpha" };
    MyClass e = new MyClass() { ID = 456, Name = "Bravo" };
    
    List<List<MyClass>> lists = new List<List<MyClass>>()
    {
        new List<MyClass>() { a, b, c },
        new List<MyClass>() { d, e },
        new List<MyClass>() { b, c, e}
    };
    
    var query = lists
                .Select(list => list.Where(item => item.ID == 123).ToList())
                .Where(list => list.Count > 0).ToList();
