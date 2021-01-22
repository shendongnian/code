    using System.Collection; // required for ICollection
    using System.Collection.Generic;
    List<int> myIntList = new List<int>();
    lock (((ICollection)myIntList).SyncRoot)
    {
        // do your synchronized stuff here...
    }
