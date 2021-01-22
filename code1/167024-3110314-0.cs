    ArrayList list = new ArrayList();
    // If all objects in the list are of the same type
    IEnumerable<MyObject> myenumerator = list.Cast<MyObject>();
    // Only get objects of a certain type, ignoring others
    IEnumerable<MyObject> myenumerator = list.OfType<MyObject>();
