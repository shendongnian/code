    IEnumerable collection = new MyGenericCollection();
    // This will call the GetEnumerator method in the non-generic interface
    foreach (object value in collection)
    {
        Console.WriteLine(value);
    }
