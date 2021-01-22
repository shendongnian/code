    private static Dictionary<ObjectTypes, string> enumLookup;
    static MyClass()
    {
        enumLookup = new Dictionary<ObjectTypes, string>();
        enumLookup.Add(ObjectTypes.TypeOne, "This is type T123");
        enumLookup.Add(ObjectTypes.TypeTwo, "This is type T234");
        // enumLookup.Add...
    }
