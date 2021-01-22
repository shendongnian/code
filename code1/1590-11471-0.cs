    // Sort according to the value of SomeAttribute
    List<MyCompositeObject> myList = ...;
    myList.Sort(delegate(MyCompositeObject a, MyCompositeObject b) 
    {
        // return -1 if a < b
        // return 0 if a == b
        // return 1 if a > b
        return a.SomeAttribute.CompareTo(b.SomeAttribute);
    };
