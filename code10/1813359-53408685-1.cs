    var list = new List<MyObject>
    {
        new MyObject
        {
            Id = 1,
            Name = "John"
        },
        new MyObject
        {
            Id = 2
        },
        new MyObject
        {
            Id = 3,
            Name = "Mary"
        },
        new MyObject
        {
            Id = 4
        }
    };
    var objects = new MyObjectLists(list);
    foreach (MyObject myObject in objects.NonNullNameObjects)
    {
        Console.WriteLine($"Object with Id {myObject.Id} has a non-null name");
    }
    foreach (MyObject myObject in objects.NullNameObjects)
    {
        Console.WriteLine($"Object with Id {myObject.Id} has a null name");
    }
