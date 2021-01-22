    Debug.Assert(list1.Count > 0);
    Debug.Assert(list1.Count >= list2.Count);
    var enum1 = list1.GetEnumerator();
    var enum2 = list2.GetEnumerator();
    enum1.MoveNext();
    while (enum2.MoveNext())
    {
        // Skip elements from list1 that aren't equal to the current entry in list2
        while (!enum1.Current.Equals(enum2.Current))
            enum1.MoveNext();
        // Fire the OnEqual event for every entry in list1 that's equal to an entry
        // in list2
        do {
            OnEqual(enum1.Current, enum2.Current); 
        } while (enum1.MoveNext() && enum1.Current.Equals(enum2.Current));
    }
    enum1.Dispose();
    enum2.Dispose();
