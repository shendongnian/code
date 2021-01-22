    // use the sequence directly
    foreach (MyObject item in GetObjects())
    {
        Console.WriteLine(item.ToString());
    }
    // ...
    // convert to an array
    MyObject[] myArray = GetObjects().ToArray();
    // ...
    // convert to a list
    List<MyObject> myList = GetObjects().ToList();
    // ...
    public IEnumerable<MyObject> GetObjects()
    {
         foreach (MyObject foo in GetObjectsFromSomewhereElse())
         {
             MyObject bar = DoSomeProcessing(foo);
             yield return bar;
         }
    }
